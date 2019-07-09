using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Models
{
    public class OpeningTime
    {
        public string Weekday { get; set; }
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
    }
}
