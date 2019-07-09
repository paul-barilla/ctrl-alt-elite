using AutoMapper;
using CTM.LoungeAccess.Factories;
using CTM.LoungeAccess.Models;
using System.Linq;
using TextResult = GoogleApi.Entities.Places.Search.Text.Response.TextResult;
using DetailsResult = GoogleApi.Entities.Places.Details.Response.DetailsResult;
using CTM.LoungeAccess.Extensions;

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

            CreateMap<DetailsResult, Lounge>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(src => src.Rating))
                .ForMember(dest => dest.SourceReferenceId, opts => opts.MapFrom(src => src.PlaceId))
                .ForMember(dest => dest.UserRatingsTotal, opts => opts.MapFrom(src => src.UserRatingsTotal))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.FormattedAddress))
                .ForMember(dest => dest.Website, opts => opts.MapFrom(src => src.Website))
                .ForMember(dest => dest.Amenities, opts => 
                {
                    opts.Condition(src => !src.Types.IsNullOrEmpty());
                    opts.MapFrom(src => src.Types.Select(a => a.ToString()));
                })
                .ForMember(dest => dest.ImageUrl, opts =>
                {
                    opts.Condition(src => !src.Photos.IsNullOrEmpty());

                    opts.MapFrom(src => ImageFactory.GetGooglePlaceImageUrl(src.Photos.FirstOrDefault().PhotoReference));
                })
                .ForMember(dest => dest.Images, opts =>
                {
                    opts.Condition(src => !src.Photos.IsNullOrEmpty());

                    opts.MapFrom(src => src.Photos.Select(photo => ImageFactory.GetGooglePlaceImageUrl(photo.PhotoReference)));
                })
                .ForMember(dest => dest.FormattedOpeningHours, opts =>
                {
                    opts.Condition(src => src.OpeningHours != null && !src.OpeningHours.WeekdayTexts.IsNullOrEmpty());

                    opts.MapFrom(src => src.OpeningHours.WeekdayTexts);
                })
                .ForMember(dest => dest.MapLink, opts => opts.MapFrom(src => src.Url))
                .ForAllOtherMembers(dest => dest.Ignore());
        }

    }
}
