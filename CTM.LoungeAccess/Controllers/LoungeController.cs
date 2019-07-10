using AutoMapper;
using CTM.LoungeAccess.Models;
using CTM.LoungeAccess.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoungeController : ControllerBase
    {
        private readonly ILoungeSearchService _loungeSearchService;

        public LoungeController(IMapper mapper)
        {
            _loungeSearchService = new LoungeSearchService(mapper);
        }

        // GET: api/Lounge/5
        [HttpGet("{id}")]
        public Lounge Get(string id)
        {
            var loungeItem = _loungeSearchService.GetById(id);
            return loungeItem;
        }

        // POST: api/Lounge/search
        [HttpPost("search")]
        public IEnumerable<Lounge> Post([FromBody] SearchRequest searchRequest)
        {
            return _loungeSearchService.GetSearchResults(searchRequest);
        }

        // POST: api/Lounge/search/google
        [HttpPost("search/google")]
        public async Task<IEnumerable<Lounge>> PostAsync([FromBody] SearchRequest searchRequest)
        {
            return await _loungeSearchService.GetSearchResultsFromGoogleAsync(searchRequest);
        }
    }
}
