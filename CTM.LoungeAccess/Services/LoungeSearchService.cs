using CTM.LoungeAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Services
{
    public class LoungeSearchService : ILoungeAccessService
    {
        public LoungeSearchService()
        {

        }

        public IEnumerable<Lounge> GetSearchResults()
        {
            return new List<Lounge>()
            {
                new Lounge
                {
                    Id = 1,
                    Title = "Qantas Club Lounge",
                    Description = "The Qantas Club Lounge at International Terminal (T1) is located after Customs on Mezzanine level. It is accessible via escalators and lift. For information about airline lounges and eligibility requirements, please contact your airline.",
                    Terminal="T1",
                    Directions = "The Qantas Club Lounge at International Terminal (T1) is located after Customs on Mezzanine level. ",
                    ImageUrl = "http://loungeindex.com/Oceania/Australia/SYD/qantas-first-lounge-sydney/qantas-first-lounge-sydney-1.jpg",
                    Rating=5,
                    OpeningHours = new List<OpeningTime>() { new OpeningTime() {} },
                    Amenities = new List<Amenity>()
                },
                new Lounge
                {
                    Id = 2,
                    Title = "American Express Lounge",
                },
                new Lounge
                {
                    Id = 3,
                    Title = "Etihad Airways First And Business Class Lounge",
                }
            };

        }
    }

    public interface ILoungeAccessService
    {

    }
}
