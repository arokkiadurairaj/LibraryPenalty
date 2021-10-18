using LibraryPenalty.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPenalty.Data
{
    public class PenaltyDBContext : DbContext
    {

        public PenaltyDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Holiday> Holidays { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here   

            modelBuilder.Entity<Country>().HasData(
                        new Country { Countryid = 1, CountryName = "India", Weekends = "0,6", CurrencyCode = "INR", PenaltyAmount = 50.00M },
                        new Country { Countryid = 2, CountryName = "United States of America", Weekends = "0,6", CurrencyCode = "USD", PenaltyAmount = 5.00M },
                        new Country { Countryid = 3, CountryName = "Europe", Weekends = "5,6", CurrencyCode = "EUR", PenaltyAmount = 5.00M },
                        new Country { Countryid = 4, CountryName = "Japan", Weekends = "0,6", CurrencyCode = "JPY", PenaltyAmount = 10.0M }
                );

            modelBuilder.Entity<Holiday>().HasData(
                     new Holiday { HolidayId = 1, CountryId = 1, StartDate = new DateTime(2021, 10, 16), EndDate = new DateTime(2021, 10, 16) },
                     new Holiday { HolidayId = 2, CountryId = 1, StartDate = new DateTime(2021, 11, 4), EndDate = new DateTime(2021, 11, 5) },
                     new Holiday { HolidayId = 3, CountryId = 1, StartDate = new DateTime(2021, 12, 25), EndDate = new DateTime(2021, 12, 25) },
                     new Holiday { HolidayId = 4, CountryId = 2, StartDate = new DateTime(2021, 12, 25), EndDate = new DateTime(2021, 12, 25) }
              );
        }
    }
}
