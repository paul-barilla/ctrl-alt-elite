using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Places;
using PlacesTextSearchResponse = GoogleApi.Entities.Places.Search.Text.Response.PlacesTextSearchResponse;

namespace CTM.LoungeAccess.Services
{
    public class GooglePlacesService : IGooglePlacesService
    {
        public GooglePlacesService()
        {

        }
        
        public async Task<PlacesTextSearchResponse> GetAirportLoungesFromTextQueryAsync(string query)
        {
            var request = new GoogleApi.Entities.Places.Search.Text.Request.PlacesTextSearchRequest()
            {              
                Query = query,
                Key = "AIzaSyAa-Cb3X-JCgyiUWJ_W3_npAc-T5tI0xjg"
            };

            return await GooglePlaces.TextSearch.QueryAsync(request);
        }
    }

    public interface IGooglePlacesService
    {
        Task<PlacesTextSearchResponse> GetAirportLoungesFromTextQueryAsync(string query);
    }
}
