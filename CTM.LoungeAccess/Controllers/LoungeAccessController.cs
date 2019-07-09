using System;
using System.Collections.Generic;
using System.Drawing;
using System.DrawingCore;
using System.Linq;
using System.Threading.Tasks;
using CTM.LoungeAccess.Models;
using CTM.LoungeAccess.Services;
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
            var service = new LoungeSearchService();
            var lounge = service.GetLoungeById(loungeId);
            if (lounge == null)
            {
                BadRequest($"Unknown Lounge with ID {loungeId}");
            }

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(lounge.Title, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            var la = new LoungeAccessCode() { LoungeId = lounge.Id, Title = lounge.Title, QRCodeImage = qrCodeImage };
            return Ok(la);
        }

    }
}
