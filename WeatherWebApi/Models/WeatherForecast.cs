using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWebApi.Models
{
    public class WeatherForecast
    {
        //Tidspunkt (dato og klokkeslæt)
        public DateTime Date { get; set; }

        //Temperatur – i grader celcius med 1 decimals nøjagtighed
        public int TemperatureC { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        //luftfugtighed - et heltal som angiver luftfugtigheden i procent
        public int Humidity { get; set; }

        //Lufttryk – i millibar med 1 decimals nøjagtighed.
        public double AirPressure { get; set; }

        //sted- består af felterne: -  Navn,  Lat, Lon
        public Place Place { get; set; }

        //navn på lokalitet
        public string Name { get; set; }

        //Lat: double (gps koordinaten latitude).
        public double Lat { get; set; }

        //Lon: double (gps koordinaten longitude).
        public double Lon { get; set; }



        public string Summary { get; set; }
    }
}
