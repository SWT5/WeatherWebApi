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
	public class DateController : ControllerBase
    {
	    private readonly IWeatherStationCrud _service;

	    public DateController(IWeatherStationCrud service)
	    {
		    _service = service;
	    }

	    [HttpGet("{id}")]
	    public IEnumerable<WeatherForecast> Get(DateTime id)
	    {
		    return _service.Get()
			    .Where(wf => wf.Date.Date.CompareTo(id.Date) == 0)
			    .ToList();
	    }
    }
}