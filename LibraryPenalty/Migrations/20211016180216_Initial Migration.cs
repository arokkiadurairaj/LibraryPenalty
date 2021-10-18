using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryPenalty.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Countryid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryName = table.Column<string>(nullable: true),
                    PenaltyAmount = table.Column<decimal>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    Weekends = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Countryid);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    HolidayId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.HolidayId);
                    table.ForeignKey(
                        name: "FK_Holidays_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Countryid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Countryid", "CountryName", "CurrencyCode", "PenaltyAmount", "Weekends" },
                values: new object[] { 1, "India", "INR", 50.00m, "0,6" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Countryid", "CountryName", "CurrencyCode", "PenaltyAmount", "Weekends" },
                values: new object[] { 2, "United States of America", "USD", 5.00m, "0,6" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Countryid", "CountryName", "CurrencyCode", "PenaltyAmount", "Weekends" },
                values: new object[] { 3, "Dubai", "AED", 5.00m, "5,6" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Countryid", "CountryName", "CurrencyCode", "PenaltyAmount", "Weekends" },
                values: new object[] { 4, "Turkey", "TRY", 10.0m, "0,6" });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "HolidayId", "CountryId", "EndDate", "StartDate" },
                values: new object[] { 1, 1, new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "HolidayId", "CountryId", "EndDate", "StartDate" },
                values: new object[] { 2, 1, new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "HolidayId", "CountryId", "EndDate", "StartDate" },
                values: new object[] { 3, 1, new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "HolidayId", "CountryId", "EndDate", "StartDate" },
                values: new object[] { 4, 2, new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_CountryId",
                table: "Holidays",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
