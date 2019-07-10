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

        // POST: api/Lounge/search
        [HttpPost("search")]
        public async Task<IEnumerable<Lounge>> PostAsync([FromBody] SearchRequest searchRequest)
        {
            return await _loungeSearchService.GetSearchResultsAsync(searchRequest);
        }
    }
}
