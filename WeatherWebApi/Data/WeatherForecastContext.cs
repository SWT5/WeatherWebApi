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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>().HasKey(W => new {W.Date, W.placeFK});
            modelBuilder.Entity<Place>().HasKey(P => new {P._Name});


            //realations

            modelBuilder.Entity<Place>()
                .HasOne(p => p.WeatherForecast)
                .WithOne(w => w.Place)
                .HasForeignKey<WeatherForecast>(w => w.placeFK);
            
        }



    }
}
