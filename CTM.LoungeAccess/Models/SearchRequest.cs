using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Models
{
    public class SearchRequest
    {
        public string AirportCode { get; set; }

        public IEnumerable<string> Amenities { get; set; }
    }
}
