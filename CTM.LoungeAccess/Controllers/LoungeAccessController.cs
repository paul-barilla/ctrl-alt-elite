﻿using AutoMapper;
using CTM.LoungeAccess.Models;
using CTM.LoungeAccess.Services;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;

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
        [HttpGet]
        public ActionResult Get(string id, string airportCode)
        {
            if (string.IsNullOrEmpty(id)) 
                return BadRequest($"Could not find the lounge with ID {id}");
            if (string.IsNullOrEmpty(id))
                return BadRequest($"Could not find the airport code with ID {airportCode}");

            var lacs = new List<LoungeAccessCode>();
            var lounges = _loungeSearchService.GetSearchResultsAsync(new SearchRequest() { AirportCode = airportCode, Amenities = new List<string>() }).GetAwaiter().GetResult();
            var found = lounges.FirstOrDefault(l => l.Id == id);
            if (found == null)
            {
                return BadRequest($"Could not find the lounge access code for ID {id}");
            }
            else
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(found.Title, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new Base64QRCode(qrCodeData);
                var qrCodeImage = qrCode.GetGraphic(20);

                //fake the id as if we were storing the lounge access code in a database
                Random random = new Random();
                var randomLoungeAccessId = random.Next(1, 100);

                var lac = new LoungeAccessCode() { LoungeId = found.Id, LoungeTitle = found.Title, LoungeAccessId = randomLoungeAccessId, QRCode = qrCodeImage };
                return Ok(lac);
            }
        }

        //// POST: api/LoungeAccess/5
        //[HttpPost("{id}")]
        //public ActionResult Post(int id)
        //{
        //    var lounge = _loungeSearchService.GetById(id);
        //    if (lounge == null)
        //    {
        //        BadRequest($"Could not match lounge for ID {id}");
        //    }

        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(lounge.Title, QRCodeGenerator.ECCLevel.Q);
        //    var qrCode = new Base64QRCode(qrCodeData);
        //    var qrCodeImage = qrCode.GetGraphic(20);

        //    var la = new LoungeAccessCode() { LoungeId = lounge.Id, LoungeTitle = lounge.Title, LoungeAccessId = 1, QRCode = qrCodeImage };
        //    return Ok(la);
        //}


    }
}
