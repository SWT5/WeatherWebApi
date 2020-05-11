using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherWebApi.Models;
using WeatherWebApi.Data;

namespace WeatherWebApi.Services
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

    public class WeatherStationCrud : IWeatherStationCrud
    {
        private readonly IMongoCollection<WeatherForecast> _weatherForecast;
        public WeatherStationCrud(IWeatherStationDBSettings settings)
        {
            var client = new MongoClient(settings.connectionString);
            var database = client.GetDatabase(settings.DBName);

            _weatherForecast = database.GetCollection<WeatherForecast>(settings.weatherStationCollection);
        }

        public List<WeatherForecast> Get() =>
            _weatherForecast.Find(book => true).ToList();

        public WeatherForecast Get(string id) =>
            _weatherForecast.Find<WeatherForecast>(wo => wo.Id == id).FirstOrDefault();

        public WeatherForecast Create(WeatherForecast book)
        {
            _weatherForecast.InsertOne(book);
            return book;
        }

        public void Update(string id, WeatherForecast weatherForecast) =>
            _weatherForecast.ReplaceOne(wo => wo.Id == id, weatherForecast);

        public void Remove(WeatherForecast weatherForecast) =>
            _weatherForecast.DeleteOne(wo => wo.Id == weatherForecast.Id);

        public void Remove(string id) =>
            _weatherForecast.DeleteOne(wo => wo.Id == id);
    }
}
