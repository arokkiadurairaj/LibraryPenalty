using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryPenalty.Models;
using LibraryPenalty.Data.Entities;
using LibraryPenalty.Data;
using Microsoft.EntityFrameworkCore;
using LibraryPenalty.Data.DTO;

namespace LibraryPenalty.Controllers
{
    public class HomeController : Controller
    {
        private readonly PenaltyDBContext context;

        public HomeController(PenaltyDBContext context)
        {
            this.context = context;
        }
       

        [Route("api/countries")]
        public async Task<List<CountryDTO>> GetCountries()
        {
            return await context.Countries.Select(c => new CountryDTO() { CountryId = c.Countryid, CountryName = c.CountryName }).ToListAsync();
        }

        [HttpPost]
        [Route("api/penalty")]
        public async Task<PenaltyDTO> CalculatePenalty([FromBody]CalculatePenaltyModel calculatePenaltyModel)
        {

            var penaltyDTO = new PenaltyDTO();

            var country = await context.Countries.
                                        Include(c => c.Holidays).FirstOrDefaultAsync(c => c.Countryid == calculatePenaltyModel.CountryId);
            if (country != null)
            {
                var weekends = country.Weekends.Split(",").Select(w => Convert.ToInt32(w)).ToList();
                //var businessDays = 0;
                //penaltyDTO.CurrencySymbol = country.CurrencySymbol;
                for (var day = calculatePenaltyModel.CheckoutDate.Value; day.Date <= calculatePenaltyModel.ReturnDate; day = day.AddDays(1))
                {
                    if (!weekends.Contains((int)day.DayOfWeek) && !country.Holidays.Any(h => h.StartDate <= day && h.EndDate >= day))
                    {
                        penaltyDTO.Businessdays++;
                    }                    
                }

                if (penaltyDTO.Businessdays > 10)
                {
                    penaltyDTO.PenaltyDays = penaltyDTO.Businessdays - 10;
                    penaltyDTO.PenaltyAmount = country.PenaltyAmount * penaltyDTO.PenaltyDays;
                    penaltyDTO.CurrencyCode = country.CurrencyCode;
                }
            }
            else
            {
                return null;
            }
          

            return penaltyDTO;
        }
    }
}
