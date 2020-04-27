using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWebApi.Models
{
    public class WeatherForecast
    {
        //Tidspunkt (dato og klokkeslæt)
        public DateTime Date { get; set; }

        //sted- består af felterne: -  Navn,  Lat, Lon
        public Place Place { get; set; }

        public string placeFK { get; set; }

        //Temperatur – i grader celcius med 1 decimals nøjagtighed
        public int TemperatureC { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        //luftfugtighed - et heltal som angiver luftfugtigheden i procent
        public int Humidity { get; set; }

        //Lufttryk – i millibar med 1 decimals nøjagtighed.
        public double AirPressure { get; set; }


        public string Summary { get; set; }
    }
}
