using AutoMapper;
using CTM.LoungeAccess.Extensions;
using CTM.LoungeAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Services
{
    public class LoungeSearchService : ILoungeSearchService
    {
        private readonly IGooglePlacesService _googlePlacesService;
        private readonly IMapper _mapper;

        public LoungeSearchService(IMapper mapper)
        {
            _googlePlacesService = new GooglePlacesService();
            _mapper = mapper;
        }

        public async Task<IEnumerable<Lounge>> GetSearchResultsAsync(SearchRequest searchRequest)
        {
            var queryString = $"{searchRequest.AirportCode} airport lounges";
            
            var response = await _googlePlacesService.GetPlacesFromTextQueryAsync(queryString);
            var lounges = _mapper.Map<IEnumerable<Lounge>>(response.Results);
            return await PopulateLoungeDetails(lounges);
        }

        private async Task<IEnumerable<Lounge>> PopulateLoungeDetails(IEnumerable<Lounge> lounges)
        {
            if (lounges.IsNullOrEmpty())
                return lounges;

            var detailedLounges = new List<Lounge>();
            foreach(var lounge in lounges)
            {
                var response = await _googlePlacesService.GetPlaceDetailByIdAsync(lounge.Id);
                detailedLounges.Add(_mapper.Map<Lounge>(response.Result));
            }
            return detailedLounges;
        }
    }

    public interface ILoungeSearchService
    {
        Task<IEnumerable<Lounge>> GetSearchResultsAsync(SearchRequest searchRequest);
    }
}
