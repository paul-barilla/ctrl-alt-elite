using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Places;
using PlacesTextSearchResponse = GoogleApi.Entities.Places.Search.Text.Response.PlacesTextSearchResponse;
using PlacesDetailsResponse = GoogleApi.Entities.Places.Details.Response.PlacesDetailsResponse;

namespace CTM.LoungeAccess.Services
{
    public class GooglePlacesService : IGooglePlacesService
    {
        public GooglePlacesService()
        {

        }
        
        public async Task<PlacesTextSearchResponse> GetPlacesFromTextQueryAsync(string query)
        {
            var request = new GoogleApi.Entities.Places.Search.Text.Request.PlacesTextSearchRequest()
            {              
                Query = query,
                Key = "AIzaSyAa-Cb3X-JCgyiUWJ_W3_npAc-T5tI0xjg"
            };

            return await GooglePlaces.TextSearch.QueryAsync(request);
        }

        public async Task<PlacesDetailsResponse> GetPlaceDetailByIdAsync(string placeId)
        {
            var request = new GoogleApi.Entities.Places.Details.Request.PlacesDetailsRequest()
            {
                PlaceId = placeId,
                Key = "AIzaSyAa-Cb3X-JCgyiUWJ_W3_npAc-T5tI0xjg",
                Fields = GoogleApi.Entities.Places.Details.Request.Enums.FieldTypes.Basic |
                         GoogleApi.Entities.Places.Details.Request.Enums.FieldTypes.Contact |
                         GoogleApi.Entities.Places.Details.Request.Enums.FieldTypes.Atmosphere
            };

            return await GooglePlaces.Details.QueryAsync(request);
        }
    }

    public interface IGooglePlacesService
    {
        Task<PlacesTextSearchResponse> GetPlacesFromTextQueryAsync(string query);
        Task<PlacesDetailsResponse> GetPlaceDetailByIdAsync(string placeId);
    }
}
