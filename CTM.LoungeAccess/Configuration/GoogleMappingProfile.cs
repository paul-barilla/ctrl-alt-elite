using AutoMapper;
using CTM.LoungeAccess.Factories;
using CTM.LoungeAccess.Models;
using System.Linq;
using TextResult = GoogleApi.Entities.Places.Search.Text.Response.TextResult;

namespace CTM.LoungeAccess.Configuration
{
    public class GoogleMappingProfile: Profile
    {
        public GoogleMappingProfile()
        {
            SetupGooglePlacesDomainMappings();
        }

        public void SetupGooglePlacesDomainMappings()
        {
            CreateMap<TextResult, Lounge>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(src => src.Rating))
                .ForMember(dest => dest.SourceReferenceId, opts => opts.MapFrom(src => src.PlaceId))
                .ForMember(dest => dest.Amenities, opts => opts.MapFrom(src => src.Types.Where(x => x.HasValue).Select(x => x.Value.ToString())))
                .ForMember(dest => dest.ImageUrl, opts =>
                {
                    opts.Condition(x => x.Photos.Any());
                    opts.MapFrom(x => ImageFactory.GetGooglePlaceImageUrl(x.Photos.FirstOrDefault().PhotoReference));
                })
                .ForAllOtherMembers(dest => dest.Ignore());
        }

    }
}
