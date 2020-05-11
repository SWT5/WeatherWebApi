using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherWebApi.Models;
using WeatherWebApi.Services;

namespace WeatherWebApi.Controllers
{
    [Route("api/[controller/{id}/{id2}")]
    [ApiController]
    public class BoundaryDatesController : Controller
    {
        private readonly IWeatherStationCrud _servicesForecast;

        public BoundaryDatesController(IWeatherStationCrud service)
        {
            _servicesForecast = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get(DateTime tsOne, DateTime tsTwo)
        {
            return _servicesForecast.Get()
                .Where(wf => (DateTime.Compare(wf.Date, tsOne) >= 0) &&
                             (DateTime.Compare(wf.Date, tsOne) <= 0))
                .ToList();
        }


    }
}