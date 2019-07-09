using CTM.LoungeAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Services
{
    public class LoungeSearchService : ILoungeSearchService
    {
        private readonly IGooglePlacesService _googlePlacesService;

        public LoungeSearchService()
        {
            _googlePlacesService = new GooglePlacesService();
        }

        public Lounge GetById(int loungeId)
        {
            return GetLounges().Where(x => x.Id == loungeId).FirstOrDefault();
        }

        public IEnumerable<Lounge> GetSearchResults(SearchRequest searchRequest)
        {
            return GetLounges();
        }

        public async Task<IEnumerable<Lounge>> GetSearchResultsFromGoogleAsync(SearchRequest searchRequest)
        {
            var queryString = $"{searchRequest.AirportCode} airport lounges";

            await _googlePlacesService.GetAirportLoungesFromTextQueryAsync(queryString);

            return await Task.FromResult(new List<Lounge>());
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
                    OpeningHours = GenerateOpeningHours("05:00", "23:00"),
                    Amenities = GetAmenitiesById(1)
                },
                new Lounge
                {
                    Id = 2,
                    Title = "American Express Lounge",
                    Description="The American Express Lounge is located in the Terminal 1 departure level, adjacent to Gate 24. Created just for American Express Card Members, the lounge offers world -class, exclusive services and amenities such as complimentary gourmet seasonal dining options, a premium bar featuring a selection of local and international wines, beers and cocktails, barista-made coffees, high speed Wi-Fi and everything else you’d expect to find in a luxurious, serene and premium airport lounge. To gain entry, simply present your eligible American Express Card and same-day boarding pass at reception located near Gate 24. The American Express Lounge can be contacted on 9693 4555/6",
                    Terminal ="T1",
                    ImageUrl="https://www.americanexpress.com/content/dam/amex/idc/benefits/viajes/SYD_29671-AMX-Airport-016.jpg",
                    Rating =4,
                    OpeningHours = GenerateOpeningHours("09:00","22:30"),
                    Amenities = GetAmenitiesById(2)
                },
                new Lounge
                {
                    Id = 3,
                    Title = "Etihad Airways First And Business Class Lounge",
                    Description="The House is the home of jet set lounging - take a seat and enjoy the atmosphere. Entry to The House includes: White linen, à la carte dining with waiter service,Award-winning sparkling wines, classic cocktails & craft beer, Barista coffee, speciality teas and freshly-made smoothies & juices, Unlimited WiFi, quality newspapers and glossy magazines, Shower facilities,Unlimited WiFi, newspapers and magazines",
                    Terminal="T1",
                    Directions="",
                    ImageUrl="https://media.etihad.com/cms/webimage/BaseImage_Standard/Documents/Lounges/arrivals_standard.jpg.jpg",
                    Rating=5,
                    OpeningHours = GenerateOpeningHours("10:00","23:30"),
                    Amenities = GetAmenitiesById(3)
                }
            };
        }

        private IEnumerable<string> GetAmenitiesById(int id) 
        {
            var amenities = new List<string>();
            amenities.Add("Wifi");

            switch (id) {
                case 1:
                    amenities.Add("Alcohol");
                    amenities.Add("Printing");
                    amenities.Add("Food");
                    amenities.Add("Showers");
                    break;
                case 2:
                    amenities.Add("Alcohol");
                    amenities.Add("Food");
                    break;
                case 3:
                    amenities.Add("Alcohol");
                    amenities.Add("Food");
                    amenities.Add("Showers");
                    break;
            }

            return amenities;
        }

        private IEnumerable<OpeningTime> GenerateOpeningHours(string start, string end)
        {
            var times = new List<OpeningTime>();
            var days = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            foreach(var day in days)
            {
                times.Add(new OpeningTime() { Weekday = day, OpenHour = "start", CloseHour = end });
            }
            return times;
        }
    }

    public interface ILoungeSearchService
    {
        Task<IEnumerable<Lounge>> GetSearchResultsFromGoogleAsync(SearchRequest searchRequest);
        IEnumerable<Lounge> GetSearchResults(SearchRequest searchRequest);
        Lounge GetById(int loungeId);
    }
}
