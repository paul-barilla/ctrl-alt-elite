using Newtonsoft.Json;
using System.Collections.Generic;

namespace CTM.LoungeAccess.Models
{
    public class Lounge
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Terminal { get; set; }
        public string Directions { get; set; }
        public string ImageUrl { get; set; }
        public double Rating { get; set; }
        public IEnumerable<OpeningTime> OpeningHours { get; set; }
        public IEnumerable<string> FormattedOpeningHours { get; set; }
        public int AccessLink { get; set; }
        public IEnumerable<string> Amenities { get; set; }
        public int UserRatingsTotal { get; set; }
        public string MapLink { get; set; }
        public IEnumerable<string> Images { get; set; }
        public string Website { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public Location()
        {

        }

        public Location(double latitude, double longitude)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        [JsonProperty("lat")]
        public double Latitude { get; set; }


        [JsonProperty("lng")]
        public double Longitude { get; set; }
        
    }
}
