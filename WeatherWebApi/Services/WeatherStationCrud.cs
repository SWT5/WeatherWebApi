﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherWebApi.Models;

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
        public WeatherStationCrud(IWeatherDatabaseSettings settings)
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017/");
            var database = client.GetDatabase("WeatherforecastDb");

            _weatherForecast = database.GetCollection<WeatherForecast>("WeatherForecast");
        }

        public List<WeatherForecast> Get() =>
            _weatherForecast.Find(weatherForecast => true).ToList();

        public WeatherForecast Get(string id) =>
            _weatherForecast.Find<WeatherForecast>(wo => wo.Id == id).FirstOrDefault();

        public WeatherForecast Create(WeatherForecast weatherForecast)
        {
            _weatherForecast.InsertOne(weatherForecast);
            return weatherForecast;
        }

        public void Update(string id, WeatherForecast weatherForecast) =>
            _weatherForecast.ReplaceOne(wo => wo.Id == id, weatherForecast);

        public void Remove(WeatherForecast weatherForecast) =>
            _weatherForecast.DeleteOne(wo => wo.Id == weatherForecast.Id);

        public void Remove(string id) =>
            _weatherForecast.DeleteOne(wo => wo.Id == id);

    }

    
}
