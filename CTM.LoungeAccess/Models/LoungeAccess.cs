using System;
using System.Collections.Generic;
using System.DrawingCore;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Models
{
    public class LoungeAccessCode
    {
        public int LoungeId { get; set; }
        public string Title { get; set; }
        public string QRCodeImage { get; set; }
    }
}
