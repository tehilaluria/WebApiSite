using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
namespace WebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //IUserService _userService;
        IUserServices _userServices;

        public UserController(IUserServices iuserServices)
        {
            //IUserServices userService
            _userServices = iuserServices;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<User>> Get([FromQuery] string userName, [FromQuery] string password)
        {
            User foundUser = await _userServices.getUserByEmailAndPassword(userName, password);

            if(foundUser!=null)
                return Ok(foundUser);
            return NoContent(); 

        }

        //Implement getUserById- or remove lines...
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]

        public async Task<IActionResult> Post([FromBody] User user)
         {
            //The function should return Task<ActionResult<User>>>
            User newUser = await _userServices.addUser(user);
            if(newUser!=null)
                //new { id = newUser.UserId }!!
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, newUser);
          return NoContent();   //BadRequest(), NoContent() is not suitable here!
        }
        //suggestion for shorter and nicer code- == null ? BadRequest("Password isn't strong") : CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);



        [HttpPost("check")]
        //meaningfull function name: CheckPasswordStrength
        public int check([FromBody] string pwd)
        {
            if (pwd != "")
            {
                //Call to the adjusted function in service. Don't implement logical code in the controller. 
                var result = Zxcvbn.Core.EvaluatePassword(pwd);
                return result.Score;
            }
            return -1;
        }



        // PUT api/<UserController>/5
        [HttpPut("{UserId}")]
        public async Task<IActionResult> Put(int UserId, [FromBody] User userUpdate)
        {
            //The function should return Task<ActionResult<User>>>
            //Why int?? User userUpdated= _userServices.updateUser(UserId, userUpdate); if userUpdated!=null return ok(userUpdated) else BadRequest()
            int ifSuccess =  await _userServices.updateUser(UserId, userUpdate);
            if(ifSuccess!=0)
               return Ok();   
            return BadRequest();

        }

        //Clean code -Remove unnecessary lines of code.
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }

}
