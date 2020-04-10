using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sts_i_services;
using sts_models.POCOS;

namespace sts_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _Auth;
        public AuthController(IAuthService Auth)
        {
            _Auth = Auth;
        }

        // GET: api/Auth
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserP user){
            user.Mail = user.Mail.ToLower();
            if (await _Auth.IsUserRegistered(user.Mail)) { 
                return BadRequest("User already exist"); 
            }
            await _Auth.Register(user);
            return StatusCode(201);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginP user) {
            //Checking if user exist and credentials are ok
            var userDB = await _Auth.GetAndVerifyUser(user.Mail.ToLower(),user.Password);
            if (userDB == null)
                return Unauthorized("Invalid User or password");

            var tok = _Auth.Login(userDB);
            return Ok( new{
                token = tok,
                email = user.Mail,
                expiresIn = 60
            });
        }
    }
}
