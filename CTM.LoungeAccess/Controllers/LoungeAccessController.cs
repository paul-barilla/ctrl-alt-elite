using System;
using System.Collections.Generic;
using System.Drawing;
using System.DrawingCore;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CTM.LoungeAccess.Models;
using CTM.LoungeAccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace CTM.LoungeAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoungeAccessController : ControllerBase
    {
        private readonly ILoungeSearchService _loungeSearchService;

        public LoungeAccessController(IMapper mapper)
        {
            _loungeSearchService = new LoungeSearchService(mapper);

        }
        // GET: api/LoungeAccess/5
        [HttpGet("{id}")]
        public ActionResult Get(int id, string airportCode)
        {
            var lacs = new List<LoungeAccessCode>();
            var lounges = _loungeSearchService.GetSearchResults(new SearchRequest() { AirportCode = airportCode, Amenities = new List<string>() });
            foreach(var lounge in lounges)
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(lounge.Title, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new Base64QRCode(qrCodeData);
                var qrCodeImage = qrCode.GetGraphic(20);
               
                var lac = new LoungeAccessCode() { LoungeId = lounge.Id, LoungeTitle = lounge.Title, LoungeAccessId = lounge.Id, QRCode = qrCodeImage };
                lacs.Add(lac);
            }

            var found = lacs.FirstOrDefault(l => l.LoungeAccessId == id);
            if (found == null)
            {
                return BadRequest($"Could not find the lounge access code for ID {id}");
            }

            return Ok(found);
        }

        // POST: api/LoungeAccess/5
        [HttpPost("{id}")]
        public ActionResult Post(int id)
        {
            var lounge = _loungeSearchService.GetById(id);
            if (lounge == null)
            {
                BadRequest($"Could not match lounge for ID {id}");
            }

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(lounge.Title, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new Base64QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);

            var la = new LoungeAccessCode() { LoungeId = lounge.Id, LoungeTitle = lounge.Title, LoungeAccessId = lounge.Id, QRCode = qrCodeImage };
            return Ok(la);
        }


    }
}
