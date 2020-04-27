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

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecastList_placeFK",
                table: "WeatherForecastList",
                column: "placeFK",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherForecastList_Places_placeFK",
                table: "WeatherForecastList",
                column: "placeFK",
                principalTable: "Places",
                principalColumn: "_Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherForecastList_Places_placeFK",
                table: "WeatherForecastList");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropIndex(
                name: "IX_WeatherForecastList_placeFK",
                table: "WeatherForecastList");
        }
    }
}
