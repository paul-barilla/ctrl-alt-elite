using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public int AccessLink { get; set; }
        public IEnumerable<string> Amenities { get; set; }
        public IEnumerable<string> AmenitiesDescriptions { get; set; }
        public string SourceReferenceId { get; set; }
    }
}
