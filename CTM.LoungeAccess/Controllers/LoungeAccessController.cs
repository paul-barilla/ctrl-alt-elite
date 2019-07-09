using System;
using System.Collections.Generic;
using System.Drawing;
using System.DrawingCore;
using System.Linq;
using System.Threading.Tasks;
using CTM.LoungeAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using ZXing;

namespace CTM.LoungeAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoungeAccessController : ControllerBase
    {
        // GET: api/LoungeAccess/5
        [HttpGet("{id}")]
        public ActionResult Get(int loungeId)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("SkyLounge Sydney Airport T1", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            var la = new LoungeAccessCode() { LoungeId = 1, Title = "SkyLounge", QRCodeImage = qrCodeImage };
            return Ok(la);
        }

    }
}
