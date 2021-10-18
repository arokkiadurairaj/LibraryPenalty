using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPenalty.Models
{
    public class CalculatePenaltyModel
    {
        public DateTime? CheckoutDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int CountryId { get; set; }
    }
}
