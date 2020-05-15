using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WeatherWebApi.Models;
using WeatherWebApi.Services;

namespace WeatherWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IUserCrud _service;
        //public readonly UserManager<User> _UserManager;

        public userController(IUserCrud service)
        {
            _service = service;
        }

        //[HttpGet("Register/{id}"), AllowAnonymous]
        //public ActionResult<user> Get(string userName)
        //{
        //    var user = _service.GetUser(userName);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}


        //WHAT???
        [HttpGet("Register/{id}", Name = "GetUser"), AllowAnonymous]
        public IEnumerable<user> Get(string userName)
        {
            return _service.Get()
                .Where(u => (u.UserName == userName));
        }

        [HttpPost("Register"), AllowAnonymous]
        public ActionResult<token> Register([FromBody] login UserInput)
        {
            if (_service.GetUser(UserInput.UserName) != null)
            {
                return BadRequest(new { errorMessage = "Username already exists" });
            }

            user user = new user();
            user.UserName = UserInput.UserName.ToLower();
            user.PasswordHashed = BCrypt.Net.BCrypt.HashPassword(UserInput.Password, 12); // Workfactor is set to 12 - hashing part

            _service.Create(user);

            var jwtToken = new token();
            jwtToken.Token = GenerateToken(user.UserName);

            return CreatedAtAction("Get", new { id = user.UserName }, jwtToken);
        }

        [HttpPost("Login"), AllowAnonymous]
        public ActionResult<token> Login([FromBody] login loginUser)
        {
            loginUser.UserName = loginUser.UserName.ToLower();
            var user = _service.GetUser(loginUser.UserName);
            if (user != null)
            {
                var validPass = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.PasswordHashed);
                if (validPass) return new token { Token = GenerateToken(user.UserName) };
            }

            ModelState.AddModelError(string.Empty, "Username or Password is incorrect.");
            return BadRequest(ModelState);
        }

        private string GenerateToken(string Username)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, Username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Sorry the key is a secret")),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}