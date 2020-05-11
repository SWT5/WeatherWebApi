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

namespace WeatherWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly WeatherStationCrud.IWeatherStationCrud _service;
        private readonly IHubContext<Updates> _hubContext;

        public WeatherForecastsController(WeatherStationCrud.IWeatherStationCrud service, IHubContext<Updates> hubContext)
        {
            _hubContext = hubContext;
            _service = service;
        }

        // GET: api/WeatherForecasts
        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> GetWeatherObservations() =>
            _service.Get();

        // GET: api/WeatherForecasts/5
        [HttpGet("{id}", Name = "GetObs")]
        public ActionResult<WeatherForecast> GetWeatherObservation(string id)
        {
            var weatherForecast = _service.Get(id);

            if (weatherForecast == null)
            {
                return NotFound();
            }

            return weatherForecast;
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
        public ActionResult<WeatherForecast> PostWeatherObservation(WeatherForecast weatherObservation)
        {
            _service.Create(weatherObservation);

            _hubContext.Clients.All.SendAsync("SendMessage", JsonConvert.SerializeObject(weatherObservation));

            return CreatedAtRoute("GetObs", new { id = weatherObservation.Id.ToString() }, weatherObservation);
        }

        // DELETE: api/WeatherForecasts/5
        [HttpDelete("{id}")]
        public ActionResult<WeatherForecast> DeleteWeatherObservation(string id)
        {
            var book = _service.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _service.Remove(book);

            return NoContent();
        }
    }
}
