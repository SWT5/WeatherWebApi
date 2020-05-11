using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherWebApi.Models;

namespace WeatherWebApi.Data
{
    public interface IWeatherStationDBSettings
    {
        string weatherStationCollection { get; set; }
        string userCollection { get; set; }
        string connectionString { get; set; }
        string DBName { get; set; }
    }

    public class WeatherStationDBSettings: IWeatherStationDBSettings
    {
        public string weatherStationCollection { get; set; }
        public string userCollection { get; set; }
        public string connectionString { get; set; }
        public string DBName { get; set; }
    }

    //public class WeatherForecastContext : DbContext
    //{
    //    public WeatherForecastContext(DbContextOptions<WeatherForecastContext> options)
    //        : base(options)
    //    {
    //    }
    //    public DbSet<WeatherForecast> WeatherForecastList { get; set; }
    //    public DbSet<Place> Places { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<WeatherForecast>().HasKey(W => new {W.Date, W.placeFK});
    //        modelBuilder.Entity<Place>().HasKey(P => new {P._Name});


    //        //realations

    //        modelBuilder.Entity<Place>()
    //            .HasOne(p => p.WeatherForecast)
    //            .WithOne(w => w.Place)
    //            .HasForeignKey<WeatherForecast>(w => w.placeFK);

    //    }



}

