using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherWebApi.Data;

namespace WeatherWebApi.Models
{
    public class WeatherDatabaseSettings : IWeatherDatabaseSettings
    {
        public string WeatherStationCollectionName { get; set; }
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string  DatabaseName { get; set; }
    }




    public interface IWeatherDatabaseSettings
    {
        string WeatherStationCollectionName { get; set; }
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
