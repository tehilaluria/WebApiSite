using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;
using AutoMapper;

namespace WebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServices _userServices;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserServices iuserServices, IMapper mapper, ILogger <UserController>logger)
 
        {
            _logger = logger;
            _userServices = iuserServices;//////
            _mapper = mapper;
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>/login
        [HttpPost("login")]
        async public Task<ActionResult<UserLoginDTO>> login([FromBody] UserDTO userDTO)
        {
                User user = await _userServices.getUserByEmailAndPassword(userDTO.UserName, userDTO.Password);
                if (user != null)
                {
                  _logger.LogInformation($"login attempted with UserName ,{userDTO.UserName} and password {userDTO.Password}");
                    UserLoginDTO createdUserLoginDTO = _mapper.Map<User, UserLoginDTO>(user);
                    return Ok(createdUserLoginDTO);
                }

                return NotFound();
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

        // POST api/<UserController>
        [HttpPost]

        public async Task<IActionResult> Post([FromBody] User user)
         {
            User  newUser = await _userServices.addUser(user);
            UserLoginDTO createdUserLoginDTO = _mapper.Map<User, UserLoginDTO>(newUser);
            return newUser != null?CreatedAtAction(nameof(Get), new { id = createdUserLoginDTO.UserId }, createdUserLoginDTO) : BadRequest("The password provided is too weak. Please choose a stronger password.");

        }
       
        // PUT api/<UserController>/5
        [HttpPut("{UserId}")]
        public async Task<ActionResult<User>> Put(int UserId, [FromBody] User userUpdate)
        {
          return await _userServices.updateUser(UserId, userUpdate)!=null? Ok(userUpdate) : BadRequest();
        }

       
      

    }

}
