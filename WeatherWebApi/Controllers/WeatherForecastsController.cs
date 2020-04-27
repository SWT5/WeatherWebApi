using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherWebApi.Data;
using WeatherWebApi.Models;

namespace WeatherWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly WeatherForecastContext _context;

        public WeatherForecastsController(WeatherForecastContext context)
        {
            _context = context;
        }

        // GET: api/WeatherForecasts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetWeatherForecastList()
        {
            return await _context.WeatherForecastList.ToListAsync();
        }

        // GET: api/WeatherForecasts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> GetWeatherForecast(DateTime id)
        {
            var weatherForecast = await _context.WeatherForecastList.FindAsync(id);

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
        public async Task<IActionResult> PutWeatherForecast(DateTime id, WeatherForecast weatherForecast)
        {
            if (id != weatherForecast.Date)
            {
                return BadRequest();
            }

            _context.Entry(weatherForecast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherForecastExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WeatherForecasts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> PostWeatherForecast(WeatherForecast weatherForecast)
        {
            _context.WeatherForecastList.Add(weatherForecast);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WeatherForecastExists(weatherForecast.Date))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetWeatherForecast", new { id = weatherForecast.Date }, weatherForecast);
            return CreatedAtAction(nameof(GetWeatherForecast), new {id = weatherForecast.Date}, weatherForecast);
        }

        // DELETE: api/WeatherForecasts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WeatherForecast>> DeleteWeatherForecast(DateTime id)
        {
            var weatherForecast = await _context.WeatherForecastList.FindAsync(id);
            if (weatherForecast == null)
            {
                return NotFound();
            }

            _context.WeatherForecastList.Remove(weatherForecast);
            await _context.SaveChangesAsync();

            return weatherForecast;
        }

        private bool WeatherForecastExists(DateTime id)
        {
            return _context.WeatherForecastList.Any(e => e.Date == id);
        }
    }
}
