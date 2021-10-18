using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPenalty.Data.DTO
{
    public class PenaltyDTO
    {
        public int Businessdays { get; set; }
        public decimal PenaltyAmount { get; set; }
        public int PenaltyDays { get; set; }
        public string CurrencyCode { get; set; }
    }
}
