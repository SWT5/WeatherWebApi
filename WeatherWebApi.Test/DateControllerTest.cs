using Xunit;
using WeatherWebApi.Models;
using WeatherWebApi.Services;
using Moq;
using System;
using System.Collections.Generic;
using WeatherWebApi.Controllers;

namespace WeatherWebApi.Test
{
    public class DateControllerTest
    {
        [Fact]
        public void ForecastResultDate()
        {
            var mock = new Mock<IWeatherStationCrud>();
            mock.Setup(mock => mock.Get())
                .Returns(GetDummyDataWeatherForecasts);

            var controller = new DateController(mock.Object);

            var DateTest = new DateTime(2017, 12, 24);

            var TestList = controller.Get(DateTest);

            Assert.Collection(TestList, item=> Assert.Contains("TestDay24 no. 1", item.Id),
                item => Assert.Contains("TestDay24 no. 2", item.Id));
            Assert.All(TestList, item => Assert.DoesNotContain("TestDay26", item.Id));
        }

        private List<WeatherForecast> GetDummyDataWeatherForecasts()
        {
            var place = new Place();
            
            var forecasts = new List<WeatherForecast>();
            forecasts.Add(new WeatherForecast()
            {
                Id = "TestDay24 no. 1",
                Date = new DateTime(2017, 12, 24),
                Place = place,
                TemperatureC = 20,
                Humidity = 60,
                AirPressure = 15
            });
            forecasts.Add(new WeatherForecast()
            {
                Id = "TestDay24 no. 2",
                Date = new DateTime(2017, 12, 24),
                Place = place,
                TemperatureC = 22,
                Humidity = 70,
                AirPressure = 10
            });
            forecasts.Add(new WeatherForecast()
            {
                Id = "TestDay26",
                Date = new DateTime(2017, 12, 26),
                Place = place,
                TemperatureC = 30,
                Humidity = 90,
                AirPressure = 5
            });
            return forecasts;
        }
    }
}
