using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}