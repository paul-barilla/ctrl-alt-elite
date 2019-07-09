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
        // GET: api/Lounge
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Lounge/5
        [HttpGet("{id}", Name = "Get")]
        public Lounge Get(int id)
        {
            LoungeSearchService l = new LoungeSearchService();

            var loungeItem = l.GetSearchResults().Where(q => q.Id == id).FirstOrDefault();

            return loungeItem;
        }

        // POST: api/Lounge/search
        [HttpPost]
        public void Post([FromBody] SearchRequest searchRequest)
        {
            
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
