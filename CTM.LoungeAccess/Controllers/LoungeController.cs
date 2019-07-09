using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTM.LoungeAccess.Models;
using CTM.LoungeAccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTM.LoungeAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoungeController : ControllerBase
    {
        private readonly ILoungeSearchService _loungeSearchService;

        public LoungeController()
        {
            _loungeSearchService = new LoungeSearchService();
        }
        // GET: api/Lounge
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Lounge/5
        [HttpGet("{id}")]
        public Lounge Get(int id)
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

        // POST: api/Lounge
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Lounge/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
