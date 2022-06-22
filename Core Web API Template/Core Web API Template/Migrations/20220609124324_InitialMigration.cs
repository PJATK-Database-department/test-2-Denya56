using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Web_API_Template.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityDicts",
                columns: table => new
                {
                    IdCityDict = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityDicts", x => x.IdCityDict);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    IdPassenger = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassportNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.IdPassenger);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    IdPlane = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.IdPlane);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    IdFlight = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdPlane = table.Column<int>(type: "int", nullable: false),
                    IdCityDict = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.IdFlight);
                    table.ForeignKey(
                        name: "FK_Flights_CityDicts_IdCityDict",
                        column: x => x.IdCityDict,
                        principalTable: "CityDicts",
                        principalColumn: "IdCityDict",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Planes_IdPlane",
                        column: x => x.IdPlane,
                        principalTable: "Planes",
                        principalColumn: "IdPlane",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flight_Passengers",
                columns: table => new
                {
                    IdFlight = table.Column<int>(type: "int", nullable: false),
                    IdPassenger = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight_Passengers", x => new { x.IdFlight, x.IdPassenger });
                    table.ForeignKey(
                        name: "FK_Flight_Passengers_Flights_IdFlight",
                        column: x => x.IdFlight,
                        principalTable: "Flights",
                        principalColumn: "IdFlight",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_Passengers_Passengers_IdPassenger",
                        column: x => x.IdPassenger,
                        principalTable: "Passengers",
                        principalColumn: "IdPassenger",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_Passengers_IdPassenger",
                table: "Flight_Passengers",
                column: "IdPassenger");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_IdCityDict",
                table: "Flights",
                column: "IdCityDict");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_IdPlane",
                table: "Flights",
                column: "IdPlane");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight_Passengers");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "CityDicts");

            migrationBuilder.DropTable(
                name: "Planes");
        }
    }
}
