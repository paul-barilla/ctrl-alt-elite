using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Factories
{
    public static class ImageFactory
    {
        //https://maps.googleapis.com/maps/api/place/photo?maxwidth=600&photoreference=CmRaAAAARdSJPgF_YmqfksONDOy3GJia-7UfVj5TM0652dxp_fa5XrNSOhCQqTvbqVyhz9g8-kpnGKWikYvhVHKkZ_Fx0BuxonG1n3k5XWvHbNoiqpEGpcHIZCkygYLc4zJg2R8OEhA6IBNbjgcqt3FSDS1lnWpJGhTED9VyavNNYJmpjHbGQwG6bZgJ-g&key=AIzaSyAa-Cb3X-JCgyiUWJ_W3_npAc-T5tI0xjg

        public static string GetNiceImageUrl(string photoReference)
        {
            var imageUrl = "";
            var gMap = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=600&photoreference=";
            var gMapKey = "AIzaSyAa-Cb3X-JCgyiUWJ_W3_npAc-T5tI0xjg";

            imageUrl = string.Format("{0}{1}&key={2}", gMap, photoReference, gMapKey);
            return imageUrl;
        }

    }
}
