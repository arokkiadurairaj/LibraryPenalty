using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPenalty.Data.Entities
{
    public class Holiday
    {
        [Key]
        public int HolidayId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

       
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
