using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleApi;
using TextResult = GoogleApi.Entities.Places.Search.Text.Response.TextResult;
using CTM.LoungeAccess.Models;

namespace CTM.LoungeAccess.Configuration
{
    public class GoogleMappingProfile: Profile
    {
        public GoogleMappingProfile()
        {
            CreateMap<TextResult, Lounge>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(src => src.Rating))
                .ForMember(dest => dest.SourceReferenceId, opts => opts.MapFrom(src => src.PlaceId))
                .ForMember(dest => dest.Amenities, opts => opts.MapFrom(src => src.Types.Where(x => x.HasValue).Select(x => x.Value.ToString())))
                .ForAllOtherMembers(dest => dest.Ignore());
        }

    }
}
