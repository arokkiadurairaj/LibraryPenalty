using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPenalty.Data.Entities
{
    public class Country
    {
        [Key]
        public int Countryid { get; set; }
        public string CountryName { get; set; }
        public decimal PenaltyAmount { get; set; }
        public string CurrencyCode { get; set; }
        public string Weekends { get; set; }
        public List<Holiday> Holidays { get; set; }
    }
}
