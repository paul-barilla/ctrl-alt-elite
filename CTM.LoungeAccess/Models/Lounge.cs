using System.Collections.Generic;

namespace CTM.LoungeAccess.Models
{
    public class Lounge
    {
        public int Id { get; set; }
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
        public IEnumerable<string> AmenitiesDescriptions { get; set; }
        public string SourceReferenceId { get; set; }
        public int UserRatingsTotal { get; set; }
        public string MapLink { get; set; }
        public IEnumerable<string> Images { get; set; }
        public string Website { get; set; }
    }
}
