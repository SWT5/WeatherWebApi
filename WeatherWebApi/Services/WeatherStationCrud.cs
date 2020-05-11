using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using WeatherWebApi.Models;
using WeatherWebApi.Data;

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

        public class WeatherStationCrud : IWeatherForecast
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
                _weatherForecast.Find<WeatherForecast>(wo => wo. == id).FirstOrDefault();

            public WeatherObservation Create(WeatherObservation book)
            {
                _weatherObservations.InsertOne(book);
                return book;
            }

            public void Update(string id, WeatherObservation weatherObservation) =>
                _weatherObservations.ReplaceOne(wo => wo.ID == id, weatherObservation);

            public void Remove(WeatherObservation weatherObservation) =>
                _weatherObservations.DeleteOne(wo => wo.ID == weatherObservation.ID);

            public void Remove(string id) =>
                _weatherObservations.DeleteOne(wo => wo.ID == id);
        }
    }
}
