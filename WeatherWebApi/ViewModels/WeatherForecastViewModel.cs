using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace WeatherWebApi.ViewModels
{
    public class WeatherForecastViewModel
    {
        public List<WeatherForecast> WeatherForecasts { get; set; }

        public WeatherForecast CurrentForecast { get; set; }
        
        public string Place { get; set; }

        public int TemperatureF { get; set; }  //=> 32 + (int)(TemperatureC / 0.5556);
    }
}
