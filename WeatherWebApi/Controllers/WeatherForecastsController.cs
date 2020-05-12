using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.IO;
using WeatherWebApi.Data;
using WeatherWebApi.Models;
using WeatherWebApi.Services;
using WeatherWebApi.Hubs;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace WeatherWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly IWeatherStationCrud _service;
        private readonly IHubContext<Updates> _hubContext;

        public WeatherForecastsController(IWeatherStationCrud service, IHubContext<Updates> hubContext)
        {
            _hubContext = hubContext;
            _service = service;
        }

        // GET: api/WeatherForecasts
        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> GetWeatherObservations() =>
            _service.Get();

        // GET: api/WeatherForecasts/5
        //[HttpGet("{id}", Name = "GetObs")]
        //public ActionResult<WeatherForecast> GetWeatherObservation(string id)
        //{
        //    var weatherForecast = _service.Get(id);

        //    if (weatherForecast == null)
        //    {
        //        return NotFound();
        //    }

        //    return weatherForecast;
        //}

        [HttpGet("{id}")]
        public IEnumerable<WeatherForecast> Get(string id)
        {
            return _service.Get()
                .Where(wf => wf.Date.Date.CompareTo(id) == 0)
                .ToList();
        }

        // PUT: api/WeatherForecasts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutWeatherObservation(string id, WeatherForecast weatherForecast)
        {
            var obs = _service.Get(id);

            if (obs == null)
            {
                return NotFound();
            }

            _service.Update(id, weatherForecast);

            return NoContent();
        }

        // POST: api/WeatherForecasts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Authorize]
        public ActionResult<WeatherForecast> PostWeatherForecast(WeatherForecast weatherForecast)
        {
            _service.Create(weatherForecast);

            _hubContext.Clients.All.SendAsync("SendMessage", JsonConvert.SerializeObject(weatherForecast));

            return CreatedAtRoute("GetObs", new { id = weatherForecast.Id.ToString() }, weatherForecast);
        }

        // DELETE: api/WeatherForecasts/5
        [HttpDelete("{id}")]
        public ActionResult<WeatherForecast> DeleteWeatherForecast(string id)
        {
            var weather = _service.Get(id);

            if (weather == null)
            {
                return NotFound();
            }

            _service.Remove(weather.Id);

            return NoContent();
        }
    }
}
