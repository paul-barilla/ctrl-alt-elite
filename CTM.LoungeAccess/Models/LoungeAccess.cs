using System;
using System.Collections.Generic;
using System.DrawingCore;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Models
{
    public class LoungeAccessCode
    {
        public string LoungeId { get; set; }
        public string LoungeTitle { get; set; }
        public int LoungeAccessId { get; set; }
        public string QRCode { get; set; }
    }
}
