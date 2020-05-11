using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherWebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    _Name = table.Column<string>(nullable: false),
                    _Lat = table.Column<double>(nullable: false),
                    _Lon = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x._Name);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecastList",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    placeFK = table.Column<string>(nullable: false),
                    TemperatureC = table.Column<int>(nullable: false),
                    Humidity = table.Column<int>(nullable: false),
                    AirPressure = table.Column<double>(nullable: false),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecastList", x => new { x.Date, x.placeFK });
                    table.ForeignKey(
                        name: "FK_WeatherForecastList_Places_placeFK",
                        column: x => x.placeFK,
                        principalTable: "Places",
                        principalColumn: "_Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecastList_placeFK",
                table: "WeatherForecastList",
                column: "placeFK",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecastList");

            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}
