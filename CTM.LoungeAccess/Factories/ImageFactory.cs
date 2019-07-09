using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Factories
{
    public static class ImageFactory
    {
        public static string GetGooglePlaceImageUrl(string photoReference)
        {
            var imageUrl = "";
            var gMap = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=600&photoreference=";
            var gMapKey = "AIzaSyAa-Cb3X-JCgyiUWJ_W3_npAc-T5tI0xjg";

            imageUrl = string.Format("{0}{1}&key={2}", gMap, photoReference, gMapKey);
            return imageUrl;
        }

    }
}
