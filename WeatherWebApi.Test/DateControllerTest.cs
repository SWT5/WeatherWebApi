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

            var DateTest = new DateTime(2019, 10, 20);

            var TestList = controller.Get(DateTest);

            Assert.Collection(TestList, item=> Assert.Contains("TD20 #1", item.Id),
                item => Assert.Contains("TD20 #2", item.Id));
            Assert.All(TestList, item => Assert.DoesNotContain("TD10", item.Id));
        }

        private List<WeatherForecast> GetDummyDataWeatherForecasts()
        {
            var place = new Place();
            
            var forecasts = new List<WeatherForecast>();
            forecasts.Add(new WeatherForecast()
            {
                Id = "TD20 #1",
                Date = new DateTime(2019, 10, 20),
                Place = place,
                TemperatureC = 24,
                Humidity = 50,
                AirPressure = 20
            });
            forecasts.Add(new WeatherForecast()
            {
                Id = "TD20 #2",
                Date = new DateTime(2019, 10, 20),
                Place = place,
                TemperatureC = 28,
                Humidity = 65,
                AirPressure = 15
            });
            forecasts.Add(new WeatherForecast()
            {
                Id = "TD26",
                Date = new DateTime(2019, 10, 10),
                Place = place,
                TemperatureC = 34,
                Humidity = 85,
                AirPressure = 10
            });
            return forecasts;
        }
    }
}
