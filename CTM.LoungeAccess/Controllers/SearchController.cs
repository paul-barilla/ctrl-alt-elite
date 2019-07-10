using AutoMapper;
using CTM.LoungeAccess.Models;
using CTM.LoungeAccess.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILoungeSearchService _loungeSearchService;
        public SearchController(IMapper mapper)
        {
            _loungeSearchService = new LoungeSearchService(mapper);
        }

        public async Task<IActionResult> Index(string airportcode)
        {
            SearchRequest searchRequest = new SearchRequest() { AirportCode = string.IsNullOrEmpty(airportcode) ? "SYD" : airportcode };

            ViewBag.AirportCode = string.IsNullOrEmpty(airportcode) ? "SYD" : airportcode;

            var something = await _loungeSearchService.GetSearchResultsFromGoogleAsync(searchRequest);

            List<Lounge> list = new List<Lounge>();
            list = something.ToList();

            return View(list);
        }
    }
}