using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWebApi.Services
{
    public class WeatherStationCrud
    {
        public interface IWeatherStationCrud
        {
            List<WeatherForecast> Get();
            WeatherForecast Get(string id);
            WeatherForecast Create(WeatherForecast book);
            void Update(string id, WeatherForecast weatherForecast);
            void Remove(WeatherForecast weatherForecast);
            void Remove(string id);
        }

        public class WeatherStationCrud
    }
}
