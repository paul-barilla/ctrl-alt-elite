using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Places;

namespace CTM.LoungeAccess.Services
{
    public class GooglePlacesService : IGooglePlacesService
    {
        public GooglePlacesService()
        {

        }
        
        public async Task GetAirportLoungesFromTextQueryAsync(string query)
        {
            var request = new GoogleApi.Entities.Places.Search.Text.Request.PlacesTextSearchRequest()
            {              
                Query = query,
                Key = "AIzaSyAa-Cb3X-JCgyiUWJ_W3_npAc-T5tI0xjg"
            };

            var response = await GooglePlaces.TextSearch.QueryAsync(request);
        }
    }

    public interface IGooglePlacesService
    {
        Task GetAirportLoungesFromTextQueryAsync(string query);
    }
}
