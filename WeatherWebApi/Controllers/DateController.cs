using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherWebApi.Services;

namespace WeatherWebApi.Controllers
{
    public class DateController : ControllerBase
    {
	    private readonly WeatherStationCrud.IWeatherStationCrud _service;

	    public DateController(WeatherStationCrud.IWeatherStationCrud service)
	    {
		    _service = service;
	    }

	    [HttpGet("{id}")]
	    public IEnumerable<WeatherObservations> Get(DateTime id)
	    {
		    return _service.Get()
			    .Where(wo => wo.TimeStamp.Date.CompareTo(id.Date) == 0)
			    .ToList();
	    }
    }
}