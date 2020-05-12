using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWebApi.Models
{
    public interface IWeatherForecast
    {
        string Id { get; set; }
        DateTime Date { get; set; }
        Place Place { get; set; }
        double TemperatureC { get; set; }
        int Humidity { get; set; }
        double AirPressure { get; set; }
    }

    public class WeatherForecast: IWeatherForecast
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        //Id
        public string Id { get; set; }
        //Tidspunkt (dato og klokkeslæt)
        public DateTime Date { get; set; }

        //sted- består af felterne: -  Navn,  Lat, Lon
        public Place Place { get; set; }

        //Temperatur – i grader celcius med 1 decimals nøjagtighed
        public double TemperatureC { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        //luftfugtighed - et heltal som angiver luftfugtigheden i procent
        public int Humidity { get; set; }

        //Lufttryk – i millibar med 1 decimals nøjagtighed.
        public double AirPressure { get; set; }
    }

    public interface IPlace
    {
        string Name { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
    public class SpecificPlace: IPlace
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
