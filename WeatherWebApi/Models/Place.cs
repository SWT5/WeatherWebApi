using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWebApi.Models
{
    public class Place
    {
        public Place(string name, double lat, double lon)
        {
            _Name = name;
            _Lat = lat;
            _Lon = lon;
        }

        //Navn: string (navn på lokalitet).
        public string _Name { get; set; }

        //Lat: double (gps koordinaten latitude).
        public double _Lat { get; set; }

        //Lon: double (gps koordinaten longitude).
        public double _Lon { get; set; }
    }
}
