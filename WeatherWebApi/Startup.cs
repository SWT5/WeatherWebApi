using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeatherWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WeatherWebApi.Hubs;
using WeatherWebApi.Models;
using WeatherWebApi.Services;

namespace WeatherWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
	        services.Configure<WeatherDatabaseSettings>(
		        Configuration.GetSection(nameof(WeatherDatabaseSettings)));
            
            services.AddSingleton<IWeatherDatabaseSettings>(sp => sp.GetRequiredService<IOptions<WeatherDatabaseSettings>>().Value);

            services.AddSingleton<IWeatherStationCrud>(sp => sp.GetService<WeatherStationCrud>());
            services.AddAuthentication(options =>
            {
	            options.DefaultAuthenticateScheme = "Jwt";
	            options.DefaultChallengeScheme = "JwT";
            }).AddJwtBearer("Jwt", options =>
            {
	            options.TokenValidationParameters = new TokenValidationParameters
	            {
                    ValidateAudience = false,
                    ValidateIssuer = false,
		            ValidateIssuerSigningKey = true,
		            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("keep it secret keep it safe")),
		            ValidateLifetime = true, //validate the expiration and not before values
		            ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration
	            };
            });

            services.AddCors();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseCors(builder =>
            {
	            builder.WithOrigins("https://localhost:44341", "http://localhost:44341","https://localhost:44370")
		            .AllowAnyMethod()
		            .AllowAnyHeader()
		            .AllowCredentials();
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.Map("/updates", map =>
            //{
	           // map.UseCors(CorsOptions.AlloeAll);
	           // var hubConfiguration = new HubConfiguration
	           // {
		          //  Enable
	           // }
            //})

            app.UseEndpoints(endpoints =>
            {
	            endpoints.MapControllers();
                endpoints.MapHub<Updates>("/updates");
            });
        }
    }
}
