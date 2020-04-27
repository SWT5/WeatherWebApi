using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherWebApi.Models;

namespace WeatherWebApi.Data
{
    public class WeatherForecastContext : DbContext
    {
        public WeatherForecastContext(DbContextOptions<WeatherForecastContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecastList { get; set; }
        public DbSet<Place> Places { get; set; }
    }
}
