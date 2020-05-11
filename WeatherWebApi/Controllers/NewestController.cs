using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherWebApi.Models;
using WeatherWebApi.Services;

namespace WeatherWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewestController : ControllerBase
    {
        private readonly IWeatherStationCrud _service;
        public NewestController(IWeatherStationCrud service)
        {
            _service = service;
        }
        // GET: api/Newest
        [HttpGet]
        public WeatherForecast Get()
        {
            return _service.Get().OrderByDescending(wf => wf.Date).FirstOrDefault();
        }
    }
}