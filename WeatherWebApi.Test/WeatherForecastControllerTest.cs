﻿using Microsoft.AspNetCore.SignalR;
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
    public class WeatherForecastControllerTest
    {
        private IWeatherStationCrud _context;
        //private WeatherForecast _forecast;
        //private List<WeatherForecast> _forecastList;
        //private WeatherForecastsController _uut;
        private readonly IHubContext<Updates> _hubContext;

        [Fact]
        public void TestForCorrectReturns()
        {
            
            var mock = new Mock<IWeatherStationCrud>();
            var fakehub = new Mock<IHubContext<Updates>>();
            mock.Setup(mock => mock.Get())
                .Returns(GetTestWeatherForecast);
            var controller = new WeatherForecastsController(mock.Object, fakehub.Object); //uut
            var listOfTest = controller.GetWeatherObservation("Testing for day: number 1");
            //Assert
            Assert.Collection(listOfTest, item => Assert.Contains("Testing for day: number 1", item.ToString),
                item=>Assert.Contains("Testing for day: number 2", item.ToString));

        }

        private List<WeatherForecast> GetTestWeatherForecast()
        {
            //Arrange
            var forecast = new List<WeatherForecast>();
            var TestingPlace = new SpecificPlace();
            //Act
            forecast.Add(new WeatherForecast()
            {
                Id = "Testing for day: number 1",
                Date = new DateTime(2020, 12, 24),
                Place = TestingPlace,
                TemperatureC = 20,
                Humidity = 60,
                AirPressure = 15
            });

            forecast.Add(new WeatherForecast()
            {
                Id = "Testing for day: number 2",
                Date = new DateTime(2020, 12, 24),
                Place = TestingPlace,
                TemperatureC = 20,
                Humidity = 60,
                AirPressure = 15
            });

            forecast.Add(new WeatherForecast()
            {
                Id = "Testing for day: number 3",
                Date = new DateTime(2020, 12, 24),
                Place = TestingPlace,
                TemperatureC = 20,
                Humidity = 60,
                AirPressure = 15
            });
            return forecast;
            
        }
        
        //[Fact]
        //public void IndexActionModelIsCompleted()
        //{
        //    //Arrange
            
        //    // Act
          

        //}
        


    }

}
