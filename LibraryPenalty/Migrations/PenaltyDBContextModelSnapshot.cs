﻿// <auto-generated />
using System;
using LibraryPenalty.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryPenalty.Migrations
{
    [DbContext(typeof(PenaltyDBContext))]
    partial class PenaltyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("LibraryPenalty.Data.Entities.Country", b =>
                {
                    b.Property<int>("Countryid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryName");

                    b.Property<string>("CurrencyCode");

                    b.Property<decimal>("PenaltyAmount");

                    b.Property<string>("Weekends");

                    b.HasKey("Countryid");

                    b.ToTable("Countries");

                    b.HasData(
                        new { Countryid = 1, CountryName = "India", CurrencyCode = "INR", PenaltyAmount = 50.00m, Weekends = "0,6" },
                        new { Countryid = 2, CountryName = "United States of America", CurrencyCode = "USD", PenaltyAmount = 5.00m, Weekends = "0,6" },
                        new { Countryid = 3, CountryName = "Dubai", CurrencyCode = "AED", PenaltyAmount = 5.00m, Weekends = "5,6" },
                        new { Countryid = 4, CountryName = "Turkey", CurrencyCode = "TRY", PenaltyAmount = 10.0m, Weekends = "0,6" }
                    );
                });

            modelBuilder.Entity("LibraryPenalty.Data.Entities.Holiday", b =>
                {
                    b.Property<int>("HolidayId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("HolidayId");

                    b.HasIndex("CountryId");

                    b.ToTable("Holidays");

                    b.HasData(
                        new { HolidayId = 1, CountryId = 1, EndDate = new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), StartDate = new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { HolidayId = 2, CountryId = 1, EndDate = new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), StartDate = new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { HolidayId = 3, CountryId = 1, EndDate = new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), StartDate = new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { HolidayId = 4, CountryId = 2, EndDate = new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), StartDate = new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("LibraryPenalty.Data.Entities.Holiday", b =>
                {
                    b.HasOne("LibraryPenalty.Data.Entities.Country", "Country")
                        .WithMany("Holidays")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
