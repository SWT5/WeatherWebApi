using Microsoft.AspNetCore.SignalR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherWebApi.Controllers;
using WeatherWebApi.Hubs;
using WeatherWebApi.Models;
using WeatherWebApi.Services;
using Xunit;

namespace WeatherWebApi.Test
{
    class WeatherForecastControllerTest
    {
        private WeatherStationCrud _context;
        private WeatherForecast _forecast;
        private List<WeatherForecast> _forecastList;
        private WeatherForecastsController _uut;
        private readonly IHubContext<Updates> _hubContext;

    }
    
    //[Fact]
    //public void TestForCorrectReturns()
    //{
    //    // Arrange 
    //    var mock = new Mock<IWeatherStationCrud>();
    //    mock.Setup(mock => mock.GetType())
    //        .Returns(GetTestWeatherForecast)

    //}

    //private List<WeatherForecast> GetTestWeatherForecast()
    //{
    //    var TestingPlace = new Place();
    //    var forecast = new List<WeatherForecast>();
    //    forecast.Add(new WeatherForecast()
    //    {
    //        Id = "Testing for day: number 1",
    //        Date = new DateTime(2020, 12, 24),
    //        Place = TestingPlace,
    //        TemperatureC = 20,
    //        Humidity = 60,
    //        AirPressure = 15
    //    });

    //    forecast.Add(new WeatherForecast()
    //    {
    //        Id = "Testing for day: number 2",
    //        Date = new DateTime(2020, 12, 24),
    //        Place = TestingPlace,
    //        TemperatureC = 20,
    //        Humidity = 60,
    //        AirPressure = 15
    //    });

    //    forecast.Add(new WeatherForecast()
    //    {
    //        Id = "Testing for day: number 3",
    //        Date = new DateTime(2020, 12, 24),
    //        Place = TestingPlace,
    //        TemperatureC = 20,
    //        Humidity = 60,
    //        AirPressure = 15
    //    });
    //    return forecast;

    //}
}
