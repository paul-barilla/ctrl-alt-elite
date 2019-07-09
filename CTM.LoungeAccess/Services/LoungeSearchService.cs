using CTM.LoungeAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Services
{
    public class LoungeSearchService : ILoungeSearchService
    {
        public LoungeSearchService()
        {

        }

        public Lounge GetById(int loungeId)
        {
            return GetLounges().Where(x => x.Id == loungeId).FirstOrDefault();
        }

        public IEnumerable<Lounge> GetSearchResults(SearchRequest searchRequest)
        {
            return GetLounges();
        }

        private IEnumerable<Lounge> GetLounges()
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
                    OpeningHours = new List<OpeningTime>() { new OpeningTime() { OpenHour="05:00", CloseHour="23:00" } },
                    Amenities = new List<Amenity>() { Amenity.Alcohol, Amenity.Food, Amenity.Printing, Amenity.Showers, Amenity.Wifi },
                    AmenitiesDescriptions = GetAmenitiies(new List<Amenity>() { Amenity.Alcohol, Amenity.Food, Amenity.Printing, Amenity.Showers, Amenity.Wifi } )
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

        private IEnumerable<string> GetAmenitiies(List<Amenity> ameneites) 
        {
            var list = new List<string>();

            foreach (var item in ameneites)
            {
                Amenity enumDisplayStatus = (Amenity)item;
                string stringValue = enumDisplayStatus.ToString();
                list.Add(stringValue);
            }

            return list;

        }
    }

    public interface ILoungeSearchService
    {
        IEnumerable<Lounge> GetSearchResults(SearchRequest searchRequest);
        Lounge GetById(int loungeId);
    }
}
