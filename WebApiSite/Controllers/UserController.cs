using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
namespace WebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServices _userServices;

        public UserController(IUserServices iuserServices)
        {
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
            User  newUser = await _userServices.addUser(user);
            if(newUser!=null)

                return CreatedAtAction(nameof(Get), new { id = user.UserId }, newUser);
          return NoContent();   
        }

        [HttpPost("check")]
        public int check([FromBody] string pwd)
        {
            if (pwd != "")
            {
                var result = Zxcvbn.Core.EvaluatePassword(pwd);
                return result.Score;
            }
            return -1;
        }



        // PUT api/<UserController>/5
        [HttpPut("{UserId}")]
        public async Task<IActionResult> Put(int UserId, [FromBody] User userUpdate)
        {
          int ifSuccess=  await _userServices.updateUser(UserId, userUpdate);
            if(ifSuccess!=0)
               return Ok();   
            return BadRequest();

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }

}
