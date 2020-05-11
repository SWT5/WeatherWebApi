using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherWebApi.Models;
using WeatherWebApi.Services;

namespace WeatherWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : Controller
    {
        private readonly IuserCrud _service;
        //public readonly UserManager<User> _UserManager;

        public userController(IuserCrud service)
        {
            _service = service;
        }

        [HttpGet("Register/{id}"), AllowAnonymous]
        public ActionResult<user> Get(string userName)
        {
            var user = _service.Get(userName);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("Register"), AllowAnonymous]
        public ActionResult<Token> Register([FromBody] login UserInput)
        {
            if (_service.Get(UserInput.UserName) != null)
            {
                return BadRequest(new { errorMessage = "UserName exists in the Database "});
            }

            user User = new user();
            User.UserName = UserInput.UserName.ToLower();
            User.PasswordHashed = BCrypt.Net.BCrypt.HashPassword(UserInput.Password, 10); // Workfactor set 10

            _service.Create(user);

            var jwtToken = new DTOToken();
            jwtToken.Token = GenerateToken(user.Username);

            return CreatedAtAction("Get", new { id = user.Username }, jwtToken);
        }

    }
}