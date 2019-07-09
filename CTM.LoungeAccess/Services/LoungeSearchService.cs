﻿using CTM.LoungeAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Services
{
    public class LoungeSearchService : ILoungeSearchService
    {
        public LoungeSearchService()
        {

        }

        public Lounge GetById(int loungeId)
        {
            return GetLounges().Where(x => x.Id == loungeId).FirstOrDefault();
        }

        public IEnumerable<Lounge> GetSearchResults(SearchRequest searchRequest)
        {
            return GetLounges();
        }

        private IEnumerable<Lounge> GetLounges()
        {
            return new List<Lounge>()
            {
                new Lounge
                {
                    Id = 1,
                    Title = "Qantas Club Lounge",
                    Description = "The Qantas Club Lounge at International Terminal (T1) is located after Customs on Mezzanine level. It is accessible via escalators and lift. For information about airline lounges and eligibility requirements, please contact your airline.",
                    Terminal="T1",
                    Directions = "The Qantas Club Lounge at International Terminal (T1) is located after Customs on Mezzanine level. ",
                    ImageUrl = "http://loungeindex.com/Oceania/Australia/SYD/qantas-first-lounge-sydney/qantas-first-lounge-sydney-1.jpg",
                    Rating=5,
                    OpeningHours = new List<OpeningTime>() { new OpeningTime() { OpenHour="05:00", CloseHour="23:00" } },
                    Amenities = new List<Amenity>() { Amenity.Alcohol, Amenity.Food, Amenity.Printing, Amenity.Showers, Amenity.Wifi },
                    AmenitiesDescriptions = GetAmenitiies(new List<Amenity>() { Amenity.Alcohol, Amenity.Food, Amenity.Printing, Amenity.Showers, Amenity.Wifi } )
                },
                new Lounge
                {
                    Id = 2,
                    Title = "American Express Lounge",
                    Description="The American Express Lounge is located in the Terminal 1 departure level, adjacent to Gate 24. Created just for American Express Card Members, the lounge offers world -class, exclusive services and amenities such as complimentary gourmet seasonal dining options, a premium bar featuring a selection of local and international wines, beers and cocktails, barista-made coffees, high speed Wi-Fi and everything else you’d expect to find in a luxurious, serene and premium airport lounge. To gain entry, simply present your eligible American Express Card and same-day boarding pass at reception located near Gate 24. The American Express Lounge can be contacted on 9693 4555/6",
                    Terminal ="T1",
                    ImageUrl="data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxMSEhUTExMVFRUXFxgWFxgYGBoZFhgYFxgXFxcXGBcYHyggGR4lHRcVITEhJikrLi4uFx8zODMtNygtLisBCgoKDg0OGxAQGy8lICUvLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLf/AABEIAJ8BPgMBIgACEQEDEQH/xAAbAAACAwEBAQAAAAAAAAAAAAAFBgIDBAcBAP/EAEsQAAEDAgQCBwQHBAcHAwUAAAECAxEAIQQFEjFBUQYiYXGBkaETMrHBI0JSYnLR8BQzkrIHFYKTs9PhJENTdKLC8SVjcxYXNJS0/8QAGgEAAgMBAQAAAAAAAAAAAAAAAgMAAQQFBv/EAC0RAAICAQQBAgUDBQEAAAAAAAABAhEDBBIhMUETUQUiYXGhMpGxFIHR4fBC/9oADAMBAAIRAxEAPwBdRv6H5Gm3oqJDh/D/AN1Kegg/Hu501dEzZzvT8DVxXI+T4DOIwqFiFJnzHwoNiejDZ9xak+o+R9aPzXyaqUUSMhKxXRh0e6Ur9D5H86FYnK3ke8hQHdI8x+ddKWgVWU0l40NWRnKXGTwEd1RCyK6XjMM0RLiU95F/MXoQ7k+FX7q9J75/mv60t42GpoTkYoDcekj0qxDqDwjuM+ho/ieiSvqKSfMH5ig2L6PvI+orvAkeaZoHENSMT7STcEeUfryrNiGjFled/wDxVrjLqdgTz4/+Kzqd4KT5WqL6BMq0uD6s91WJPeD5GrA5AtMen5Va0tJsYPfRX9ClH6lQWsXSojzH/miOGzVQELhXObeEi1UnCIIlJI7JtUXsEoXjUOz8qYoKaLTlFmlXsFTIKD2bHysfECsxy4+82ox2GPMbH0oe5bgRU2MQRcHysaQ4NdMcpJ9oLsvkWcEjtH6BoTnOKb1Bts6JPXPIHgO3/TnW4ZuAk6oMCb9ndSuVhZUpW5v2XMwPXyotPiuTkwNVmqKivJpIEaU3Ei/ZM/H5Ve20YkRvB7CLdnAnsqjCp6wTc3G4m0X6ov8AryYm0I0gQpXOEkcIvABvtB4mO/emc58mRODITJ08TaAZ0k3BE8Ce3es4aIK+rJv3x3AD0PxpixOFlSSg6bqMzojfnAOwmAR7woNjXFD62rcJ0gCIEDhtAPHhyqmQEYxNgIVMae0ns8NIAttwqDWJKTqSTa6SeBHCO31FXqckwBIiRPCDeZjieBjfhWRShwmRwieZIBB77d9AS+bQ2sPB0A27ew8QDVSmINv13jjWDoyoq1psRAIm2xIJ+FHFNkD8/kaS4q6OljluimYQ2ONuRrx1iOII/W/KrVqH+hqpw8vKijBoplCjG4kcvyNeavs7DzH651Fxzy5VQp2Li36505QFWbC4FCOP68jUPZpiBY8OR/KsTiyL8eY2r1GKPHzothW9eSl/MvYqggnhG2/bTPmWU4YYUuJx4deKeo3h2iUBXJb7hAjmYB5A7UtYhAVevk4ogRJjkf1arcPIl23TfBp6LZc808nEh/QtBsQAtQkEfXEbE8DRrpXjXXilxxxb44KXfQeQTsmewCgDL6pluZ5Dfugb0yZfl+IdHWRAIvrMeEb+lIccl8cjYxxpV59xdZxMdx9KkFgGQb+XrTRh+hSdUrcURySI8yZn0o7hMhYbEBpPeoaj5qmpLE/Jame4vIVIURvHw/XyqvDOKw8jTIMGZi3D4187nijxuNp+FQTi/bDu9J4U6HZhkFcFmQcMQQe2t4VQDBphU9nzFG21ggGql2SJfqr6aqmvZoRh862FCCARQ13J0nYkeoolrEgSJO0nepqQaqiWYsDhC2CNRI5RtWqK+NeVW0KyDuGQv3kpV3gH40NxXRdhfApP3T8lSKLpq0GhcEwlNoS8V0GO7Tg7iCn1E/Cg+L6L4lG7RUOaIV6J61dPSoVYFCh9MJZDjpaW2YVKewi/ka9WRw9DB/KuwvYdDghSQociAR5GhmJ6K4VX+70n7pI9NvSjjJxC3JnJXVK3n+IfMVEyfeQlXaK6JjOgoP7t23JQn/qH5UDxPQ3ENnqoChzSQfQ9b0pMo3yh0Mi8ibjWk+zURqB5GTuRzoWw3NvHtmCB8Ka8zwLgSpC21AkGJTBnhv20tMsCYO4mZPECaZibSdiNRFbk0EcKAFCZgbiJPPYcyQLc6aMImSAskpKUgwLXKtwLpm4NuNLbETxgwQBcAC+qRt3TRzBYtMdfTMwIjVuCTPE7gEbCO2mWJZpTkDjg9uFOKSxBUCOoeNjsLGCIO3bQXEYhyxg6QZm1iDeLRAnh+VGv6zxLaFNhZDbihKQokqsIM3kT28h3h8QVBAkageKp7+rffYSeU2mpb5v+xHVcAx1Gsk79o7ASZNuJBsOJ7qwupKYO4kTw9O8xRTGK6qSowSQLaQE/asLjjeb9sChWKUIBBgGD5Dj5elQFo2ZA4pDhNx1PiRaPCmhnHA7jxB+IoPlrTuHKFONgofIEgodUlCTCleySvVx+tAMRO9aM6CUvf7OtRagGXUJQvVedKUEwnaJM70twtmrDk2xSQQdcbUOffWJcbCO6hrmJPG9Vh1KuJnkafjxsOWVGxxIVsYPI0PeJBg2ra3lzyohJjt6vqaJMZEpX7xYjkBJ/iP5VqjhkZ55oeWLYeIqxlhbnuJKp5AxPadhTfh8mZRsgE81db42rehsCnrT+7M7z+wrYTo86r3iEdnvH0t60ZwvRloe9qWe0wPIUXQmtDaaP04oHfJkMDgkNiEJSkdgA+FE201S2K0ooJMbEsSmrQmoIq4INYMjHIQXVAGOHD8qJ5Lss9onyoSrDE7bUXyZgpSqeJHwoMfYjIghh7qPdU0PkW5VFhMk91UkXNSYMAth8RNaNVAvaab1cxmINjIPaDQJjAshwpUFD3kmQeIPZVqcSS97ZQClRBn3SO1IgeNZG3QasFFZKLVqlSlbSZjgnsHZXgNQCqkKlkJVNNV16FVaIy9KDpCvqnY8D3HjUTIqYxBtJnSZTNwCOIB2qLzhWoqJlRiTzi1R0UrPUPRVyMRNZ2mSowCB2kgDzNWYjM8PhhZSXXRx+qD2c6TknGK5GwjKXRrBr2kN3p877Q6iD1juAePbW3A9PEqnW2kx9klJ+YrJ68l3Fmr+nfhobVoChBAI5G4rmHTPo+hp4r0dRZ1AoFx9pFhYi5nlwsTTyrpbhbTrTMcAd+0R8KvdxWExKCguIIPBR0nsIJ2NHDVQ8/ngCWnnXRyBvBBJga2wSoJJEza3Id5Ji9aHMGUFRSEqIGomQJgggpm03AsecU05t0beaSShPtmuC0dZSUxZKgkmR27WBsaAJxZMDWsFciNXV7RPeRtFia1RlGXMWZJRa4Z9i1aUn3kJ6gOmdJ4kceA5/V5UPxzwKACslRPWIOoKsReIvB4wL0aW9tpIgbWIJ2Ft+AO8+FDlpbJE+zM/2THKU37N772miopC5ilz7sQSTxBN4vNQaZKzERYSeQHzo47kClJ9olKktym6iT7ygnq6hKt5nbypownRllsRp1cyq8+G3pTceJzL4vkVmCYCGhrAtGnbvUK2s5RiHB1wEDtOo+Q/Om5LISAAAIr3TT46eC7Yx5ZPoW2ujLY99Slnv0p9L+tEMPl7aPcQlPcL+J3NEimoFBrXCMY9IzTbfZmKa+irFINeaabYmiIFTSK8Aq5CKpstI9QK0tNmvmWq3st0uUhkYkWcMa2NYWptCtKCKzZJDURQwBVmipaxXinU86xyGJnLy4U3HOjuSHUhZPMfCl5nEpWeIngfzppyjDgIIGxIqR47FT5NmCakmOVYMSqFKH3jRvKEdZX4fmKwYzAkrUYtqNVJgxMSL0SwjbWhWq6j7pn3T3cfGq1YNJvp02iAbT9ozP5VlLKhaD30NBBMNotoJsOtN5PMRsOy/fU26Gs9WZPCqG1xH0oSTMghVo2uAd9qKVJIkW7Yar1uSoJG5MDl4k2HjS/8A1kvnUkZkeJpe4MYFEgKMGEGFGOqk7XO1QDgoL+3zWYZp1oF+wEE+QvRJ2U+BnSqpqBpfYzFZ2bVHMkD0JmtSs6Qj3lJB7wT5Cr2sHcbMbiwltQKgJSoCTEkgwBSU4Fc6YMTm2HcCvoytUHraQPGTe29Yc/QwnBpKU9ZRYVNz/vkAyTEbGwBHbU/pXkdvilYMtasW2NXuaRzzGukOKH3j8TXjOIib1nzRX0y4+0r+aqmFfrwpe3g0rI9wWx+NkJvy+dW4bMiBM8KDYo2Hf+dSaVbwofTVDVmluGPD54tKBCjII491X4bNParJWlJkxMdb+IX50tIX1fKt+XK/mHwpbwRVtDlmlKkzruYdDsGdKktRKUGNayJ0g8VVlRluHZvoQkjibkf2lSRTCtcttn7iP5RXHc8zRWvEJ9oQtKEqR1QVJhDTij7Q9aValgXtHdXQx1GPPJil3wN3SHM2lMkJVqJW2ARcSHEmCRYbHc0TWoGuQ5JilrUsrWpZ+iupRUbuo511JCqdB2nQuLvksUKkhgmsrmZICikBa1AwQhta4MAwSkECxBvzq5vGOk9XDOfiUW0D1Vq9KpWmE5I3IwoFeLaFZFvYm+o4ZocCpxSz4p0pH/VQvMsQ8hDbqcS26FPNt/RtgIIUvSoSVKPMb09SFthJ1qs6kxRR9uljHtqcxSWvaLQj2S1nRAJIUhIkkExCjtTVIBoIe0A41FeYtI95aR3kD40u4lWEQohSXnCCQZWoixjYrjhyqtGcYVpRjCoRCQQYTqOq8RE8Rx40Esqj2RJsY09JcP8AVXr/AAArPkgGr288Wr93hsQv+xoHm4U0sjpa9qSENoSCFKiCVAJKhzj6pJttWd/pXi1HShSt5OlASSmYtqHYRO1JnmSCSHdvE45Xu4ZCP/keA9G0q+NWfsuOPv4jDNDsQpZ81KSPSkJhzFvhK1Pvad1QVhIEG8jqnYfrbzEZKpUrCtQsUqJk2A6vKZIEjcz455Z0wto7v4ZtN381X3ILLY9ElXrW7LujOCfTrSt54SRqW+8bjf6wHpXMWcuVMAERHDgo22NxHKusf0e4fThEi9lKnvk7dlV2rC4OZ4dq4p76O/ujPBXyFJLTopt6OOS2fxfKjydCV2MWW2We75is+KzJsKKCbgmYBn0qzLnJURxj5iuc53/+S7AVqLqjI7+7ftmpixRyOm6F5cssatKzoac1ajjb7p4cyRXyse0oCSOe0b3pTwj3UAWpM6SDccj5navhiUiOsnYcRyrYtFiut/8ABypfE8+21i815/fo2Z7mQbKdCQqZuTbhwSaScd0ncDhGlMDv+Zpta0LJJCFwhRg9YA6kXjumkfH5SdXG4HwArnarBHFku7T6/tX+Tr6HUzz46cakqvj3brv7Fo6UGbp9f9Kqf6SngFfxR8BQx7BlKj31Q4iPOlKMfBok5dMKKz51fUgJB3uokiDaSdqlhQpemV31KBSBBAABBmOc7GbGsmXR7VMjV71ufUVzo5lbSFOHS2pRE21gR4k1qwY4ykv9mTUZHCDf090v5aGLJsMlbf0mpUEgalEyB+o8K1/szYeTCUxoPC0yL99Z28Q4IAZi1usmIHcakpTsg6UhUGxVaJTxA3/Kuw5Y4qKUH37V/NHmdmbJKblkVNP/ANXX7WFMQuEKH3VfA0Izsf7Gz+Fn/HqeIW9oVPswNJn3iYg7bULzDMw4w20lK9SQ2CSIT1HAs3PypGrzLnctvyurrn8mj4ZpWq2NS+dN1fH3tIS8xEPL/Gr41FtVe4tUuqPNR+JqKNjXFXR6pdlrYkGb1pUzCRHGs+FP68KOYNAUEg8PzpU3RpxRUkD0YY6TbYiiGFwxANuIPlRpGVyDA3j4miDOUGNuFIedGuOCjpGEw8tN/gT/ACiknE/0d61rcURqUAk3UpJASlNgnQRISDua6vluW/Rtz9lPwFB8ZjHgkrDeHQiNQK3XCoJNwVJS1AMEEjUY51uWSkcx03RyzO+hzeFYUtFiFNTpFj9KgXKypUXnfhRhtF6p6cZm4WygrZMra1JShYIBdRHWUrnHCtrCYrTjlwU1ToW84xTjTOJU2soV+0IEjtaZt60n4/MsQoXW4qANSgtRTKjaYUUjssKeMzcCUYgq2ViEp7tTLSdXeJnwoKcelAcjSCVAQnUEqMrIkgieqqbSb9k0EnyLYs4cuLSpsASYVcwbSBv+Lvpuy9pQy7DhW4xiAe8PkGqc3fbTgG1NhYcKtQc2NlKhAUDJCdIFto33rXlrurLMMq5JxbZJJJJJfMkk7kmTTFO2gaHjEopWKP8Ab0/8u5/iNU5YxFKak/8AqCP+Xc/napkZ2HJC5mHRxSnHHCrSCVKAkSbzxIA33O1LuauIDywtM3SEgcIAnzEDxo1j8OsvrJcb0hxXFWqAsmCRtw8qxqwetS1F5q5lUJWrlHAbHj3UnLmg2RLg0t4bDlhDi1FM9UhHvhJJUCJMXKrnttFEMoy1sqaIWXZStQ1mCbA3N78h2cIoLimA6oNIcmydZ0hIATF5J94kRHDwNbcuwy2nA0VpUkNqdTBAMXSUmOJkxf8A0TklGRcUx2yHLShhpRElYE32SUyRFFFPNBZbcdYQVbJJ66pPBMg+POkr+s1LbU2lBT1dCTCSANiILpJtIkCi2T+zbabEtSEg2cQFCYUTp1HYniLUuWLHFW12WotsYXeiAsUr+rf6pMRy4fnRjozgVNM6FQTqJ3ne+4pYOYgqJ/aGjIjruaiLzaEiBMWHIcqaOjX7m60L6xugkp7r8auE4v5UVVM4pMU19EHJQocNXypSX4etNHQ49Rf4h8KLfZJQobMtHXUfun4ilnNMDqxRSn2alKUoxA4jVCrbwaZstHXPd8xXPc96L41eJeeR7RKVOLUg6yJEmIAM7UWPJt/H4Zny496r7/lUHmsCtIICQFA3CU9UJOkk22t8az4nC4hJJSlJQIAMESIsYMGldno9jUwpxTmlSgj317kSJBuBA3NX5h0VxzABOI0k2A9svrcCAa1w1jjzFf8AXZjyaCM0lL/uKGLAuOqgLSUWUkdWJFidxe9V5jh06oj9bVm6NtvIBS6sqUlxXWKlKHuIJCSrvE1LH4nr7/a+Jrj63PLJnd9e33SO58P00MOFJLn3+zdAfH4YFREcvgaCY7DR50347LylovFYgI17HYJmJ50pZs4fYJWCZUsGeMEKMUOnnv6fQzVw9P8AUuz3KW/pkz97+RVM/RvDnU4UoUetFgTxJ38q56jGKBnUoHmCQaJZTmjoVpS86kGbBagJ3mx5Cupps6wu6s4ur0/9RHbdI6vhsE6qNLSiVTAEarRfTMgXFzavsY0UEBaFJVpMAggnrI258a5nic3xKAVJxL4IXAIdcBAKQSJB5/Ohb+cYhRlWIeUdpLqyY3iSeweVaZfEJykrSpO/qYIfBsUE6btqvodaxeHX7JaihQGhVykx7p40sYhvSkd1Yeh2Y4hacSn2zhHswDKtViFyOtMT2USxSZQnurB8T1DyuEqrs6vwXRx00MkU76EnFfvFfiPxNeI2NWY1P0ivxH4mop2pafBprlksKaN4HVFhP6FBcPRnAPK4cz8BSshpw9Ddlr7iU+4fP86bcsynF4pvU2ltIuOsqOzgDypOwLjpTYp4U7dH+ly8I17NTGvcyF6dyTtpPOscYxc/mNk5ZFD5Ox9wjjrSEpW2VAaUyCmeAkyaR83W88kp0IDRQ1cuJCjpSgkG8i4I8KdWca4+2lQQlAUEqHWJMWO2kVRjWNUghPlWyUd3Hg5mN7Xb7ODZu06kqDmm62QCHAuYeTHGZinNgV702wBDZMD94zsP/ebrY2xFbcdJURu3YldKP3GKnhiW/wDCYPzNKDLbj6wkExaeIASkCTEDZI8uNP2Z5WvEIxbbcav2lBuYEBhib1kyroniWkx7IEncpdAmLgb/ACoJvkW0AcvbT7V1vUdKNIbkjcpOqATzCpjtpjQyE5dhwIj9rbIja788Kiz0dxyZ+hOoqBJSpuFfikmTJN4/Kt2YYZ1vAsIdBSsYpqQYmC9b3bbRRKXRKHLFJpScR/6ij/l3f8RqnJ9NKmeZe77VL7KoUEKbIKNYhRSomARxQKuMg2hHzTKip9xQQs/SLPuqj3jEQb99esZa4Nm1+CT+VM5Vj/to/wD11f5lSS9jx9dr+4X/AJlW0mWuPAvYPIlIEJQv+E/lWgdH16/aaHNRTp91URy2o8nF48fXY/uXP82rU5hmH28N/dOf5tKlEtN+wAGTvD/dO/8AX8Nqow2QvglJQ8NQSEq0OHSUk2VbYzv2DvDanNceOOGP9lwf99WDOsdywx/vB86qUr7JT9hOXkeIHVLT53tCiDyiBFdF6B4ZTeG0qSpB1qMKBBvHAihwz3H/APDwx/tuD5Gvv6/zD/g4X+9c/wAupvW2gNju6OcqApm6IplKj96PSgpwdMfRpGhtQ+98hSYMPJyMWWe+R935isejEIdWSPo+sUwJJuSkkAcorbl56x7vnThhcchKEiGkkJEki5tuaDNBTjtYOOTjK0ILBxjjrR6oRrTI0HVZYBkFQsRPpvQbFNYdKUjEMoJSHFLJLzYSVGRqUp9UyYuNXYBXWTmSP+M2nuSKGY1zBuElbqVHYnQmfOJqYtuONRRc1vdiTiek2HDKdeFSVFIPV9mZUux0GdRUQAeZtvQ/MF4fRrKABpC/dOoAjVfTfan8t4Iiy1TwgEDyTFCX8gYWokOEg8PZKPh79ZZ4U5XG/wBx2OdKmIK88YcSpkiEFMXbcUmAdoFztQoNN6sOhektl8JMpITpKVgKKVbC8wdovXWWeiLBEFkr7SI+dBs9/ozDqfokqTBKgnXpBN7FRSogX4CtGJQx8JA5smTKlud0InQroyh32qnmz7NIISoOISdXdBOxB2jnTFl+UM4ZtwnSsrMtkpBKLQAVRe8mQB3UUwPRtzB4Z1C0oClKSuEKKt4SLlKST1eArzPU3TtcE7A8auWR7gYQVHNcVkTgTAKXSTJKFGBpQBcqA3M86BqR7NQ1tkkX0qUQCO2ADHcRXTvYgbADut8K0Ze463qWlht1NgS617RCTwubCfWijldgzwrtAfodjWEtKUWm21OtuJSEcSmU/XUSbKG3OvMydiIFqPY9KVth0sJJlQhKF+zBtEI9ppCZUOHhS3nmJUQkKCUaQAkBCGxp3FkgT31NTUtozSfKpChjlfSK/Er4mq0m1fYy7h/Er4mqiuxpq6Et8s1tkeVF8ri5I7KCYFKnF6UiSdhTMxkiwkla0o4x7yvS3rSM0ox4bNmlxzycxVhvCtKHuqI42JFbP6yUmUrVq7+VfZVpKUjgABPGwisucZOskutHWOKfrbAW592/fXKjNPJUmd/URrEtqO19Hseg4do/cH5VuxABuK57lGNKcKwfuwe/9TTfleL1NJVPP0JFdlWeWlFJ2L3TxqMOo/8AuMf47dZVCtvT5ycKf/lw/wD/AENVQUU6DopdAZ7o8FuKcS44gqIJCXHEpJCQmSEqiYSBMcKsGQYge7iHP45/nSaNsN3A8KNoytXBSD4x8aqWRLguhH/qjHJ2xDx8MOof4c1lzHK8U6EpdWspS4hz90AZQoKF0jsroZwTg+qT3X+FZnUEbgjvFRSKtGJ0VjcFa8QaxuKq0XZXFXNiqQqrmzV2Q1tVtarC0a2NGgZZrQgHhVqWU/ZHkKrbVWhBpbLs+9gn7KfIVFeGR9hP8Iq4V4uhIcaRgio2BJ/W54CimFw5QLm8zbYUN/raBCR+XjzNa8qfK0kkmyvkKqJUg3l3veFa0ZI24SpbhuZiduysmWjr+HzoNiFvqdcCSYC1Ad0mikwUhzYyTCJ3v3miDLeCRwTSC3luJVxNb2Ojrp3UaWMobns5wiNgnyFYnOl7CfdAoaz0Unck1ta6Jo4iq4JRBXTlPAVld6XOK91J8qMN9F2xwrczkDY4CpZOBKx+NcxCdC29Q5EfA8KAY3KsaUhLSU2sFKk2tvKprsCMtbHAVIstjYCqslo4plWHewjocx62zqBDTYKggrEe8Y4Dhx241vy/OHXkuHEBtUJV7NBbQdBJX1kjSQAI2Ub6aeOl/R9OMQkBz2akHUlWmSFRvv6beVJz/QTEdXVj0oQgWDbKiSZJE9e8TaZAjamQmnwwJRYrZ1ma/wBm0qfWtSXnG0lakkJlpopCNPVgTwi5NqVcVmS1JQHDK9XvG5UmI3NyJ591dTzPo1hltJbXiHNSXCuUNqBnSlP1wrlNBMP0VZQslLKnhzf347BMACmSaBUWc8xiIc8TWRwiD311ZzolhDctEHiNaiB2C9QV0ewyPdaTQrIgpY7ZzvJG0FYLiXCj7gJM8O2N9r0+4d1rSAfaKEW1BRI8SJ9ai/lzI2RWM4W1kKHxjt/Kl5cSy8ts1abUy0/EUgo282kQ2lY9P5xQfG4Vxz333Yn3U8ByMW9KtbZXFgrfnPzrZh8O/JkJgnstbuoIaeMOV+RmXW5M3D4X0sqw72KQ2ENvEpEQlxAItI94XvM1swXSfHsf7pKxx0KIB/srmtaMKob6QeVvhV4w6+CAf7MfGPSnKTRldM1o6RjHsqZWn9ncC2lfS2QoIdQ4rSRJ2SeHKtGfZuygt6HdS9cCEqA63CVATNvGKCPwh1tS0gAbgGO/hb1o8vB5bi0gF1xtaSFJMiyhcW09YTwoctyjXhh4ZRxzUvZhFOZgJCrTv2+VF8lxqVpuDqT9aSbKJIn/AFpdHRNx33cU12AJUYHdqBFE8m6NYrDr1h5ojiOsJHreuXixZINWdTPLSyg9sufs/wDAfTiUxIWoA8+FQxWNUhtR1kwDfalnF9OWUplTSlqIkhRSEDxuaG//AHDISSWkhME9Q3jvUPmK2ybh2jmRhv6CGWqcLQUdSrkkkEgXMXrQ+2aDHpBhH4LqsQFgyJXKZFx1bjhRrKVLfUQhtzREha7DhYTv58KZi1MXUXaZU8Elb8GSimV4MOAyvT4SPOr3srbRd55Kfupur9eFe4MIiUSUkyJ3jtp08q8ClGzUnJzwWg+JHxqwZW6Pqz3EGq20IKpC1AxcSCPzrYQsjqrHjb4TQeq/JNhSMOsbpI8KsRNDsyz5xCw2lYEe8d5P2bjzraz0mSLOQT2XHrWd63EpbXx/A56TNtUkrs0hVfKVWDM+lOFSg9ZKVQYtx4bdtXMP6kJVzSD5iadHLCf6XYEsWSCuUWjkicvmwsKLZPh0pQqSB1t+Gwr1y5hO3E/KrMN0Pbxn0ilqSEdSEgX+tMkGPejbhUVlOjxWaJQClpSVuqhDaQQYUoi5A2ApyyvK0stIQbqCQCo7k8TQvJuh2GwzgdSFKUmYK1TvaYAAnwo08/4VZPsWgAbVJChQ5eNSKyuZskcahBkS6kVM49KaScTnxG1CcVn6jxqUVwP7+cJHGsLvSBPMVzjEZsTxnvrG5mKjxqbWS0dJd6RjnWF7pNHGuerxyudQ/bTRLGVuHh3pKeFZHekKqUjjQN6rOYJO0q7gT8KJYyt4yvZ6v7RrMrNyeNAVYlZ2T/EoD4TUOvxUB3C/mbelF6aK3BlzHzxrK7jkj3lAd5isBZTxUpXeox4gQK89q23xSnugTV7SbjYMWDsFHuBA8zAPnVgCzskD8SrjwAI9aFKzdE2ClHsEfzRU05q4fd0g8AZP5R61TaRai30HsJhlcVjwTH800WbYRuo+Zt5bGlrLC48tKNatSiBE6QPFIrpGUdHWW7ka1faVfyFLVz6Da2dgzCadm0KX+BBPrsa3DBYlXu4cjlqBJ/hgfGmtggCBWhLxq/S+oPqL2OZZ/kGJXEsOLEGYbsNrQJn12pXxGWrQYKHGzcwUlNhc2UIiL2rsOePrKVAx7LQSTPW1SIAHG1clzfF4h3EaW0K9oJtMaEJnSAvmBAvx4DhTn6aps0YdP61y6S/k+wr7zY6rluX+lx8KK/8A1liUIPWIgbxPhxAoXluZobcu0H4ADiVboVwvBAtw49sU2YPouximw60tbOoSEqGoCdxaCOUyauGRTK1GmlhfuvcQM8f6ivwmh7rpLBji2fVNNnSvoXig2r2aPbCIlsyRebpMK8gaWX8GpDRCkkKDd0kFKgQOINxQZa4+5ent7l9C5jFKS4lSSQQZBFiLGnjIs3feQr2jyzCo3i0DeInjvSOyz1gP1saL5NnqsIsgHcgx4AWm1VCG/G0iZ3tyJv2HtOAdUDoQpXhE+JtW/LW32kALw7kDlCj4hBNDMt/pCTs4I7dvUW9KacB0pZc2V8CPS/pQelKIqWRvoxpzHDk+6EnjEpPjFV5xjm22taVq1EwkSIJ5m2w38qZ0YppwR1V9lj6GgmfdFWX4KVFpQ20gaPFJ+RFBNS28B6fJj9RepdCGl0qJJPHc1e/idIvEnjVWY9H8YwoyyXUDZxnrW+81OsHu1d9V4fHYUFP7UlxSAYhPMcFgkEDuvXOeCcpqLR6KWow7PUTtL27M2WYIYl8JccShAuSpUJ7p4TXVU4BtttBceAsBNgk24T2dtCGummES1pwwCtIASgIKEp5TIAjupYxmYLeVqWZ5AWA7AOFdHHBY1RwtXqZ6qafSXSBHtQBTN0TxcNLuP3n/AGppAfxd4/U0wZDitDSoO6t+ZgA/CtEUZZDXi8zjjQh/M/1NCsRiVKNZHnbGf14UW0GzZiMy/XfQ57HnnWL9sQskI1LIOyQB/ORXpw7psEJT2qVqPkIHrV0kVZ87iCazLWa0oyxZ3cPckBI9ZPrUxkqPrDUfvEq/mmKlolMELxKZ94E8h1j5Jk1ErUdkKI7YSPUz6Uwt5emNvlVeIShA1KOlPdPwqbiUAA04fsp81flUxgj9ZSj2TH8sH1rSrNGyPo0qX22Sn1v6VmOLcUQE6Uzy6x8zA9KLel2RQb6Pf2FIvpE9tz5m9QfeQiylgHlN/LeovYNR95Slf2o9EwKzJwxTIEAcgKr1V4D9GRFeYj6qVHwj+a/pWVWPcOwCfM+pirkNXnfkJNbstyhTpUApIjeZJvO1oO1T1G+EX6S8gNTi1bqVHl6Jj1ryIuAB2x+VOSeiqE+8oq9B5C/rVjmWIbEpt+EDV23O4iTB8OFFTfZXC6FFth3fh5T51rS3CQVE8oSb3ubnampOCi0gqCdVxMdoJ+FQ/qVZGqSZAuVbztbx5c+yqcIk3y8ALK3ChQcQ5AQoEEDUoHcJMq49tu29dW6NdJmsSAn3HOKCd/wn63xrneNZLQ0hYJ4zqJEwI39R5WqvCOr0lfVAAGlQAEqM7gCx7RxNWlXQttvs7ahVWg1yvIOluKZOl9PtkjjIDgHYdlCJN710PK82bfTKCbRIIggkTB4eRNEUasQ3qSUkWIpVxfQ5KlFxrV7QbKkWmbRaBwMaiZHdTiDUJoJ44z/UhuHUZMT+RnI/6lKXIVMqMkJB61hIUoi3C9/nT7gVqCQkIIAAEDbuija0CqzUjjjHoLNqZ5f1ft4PMJIurflNSx2DZfTpebQsbdYTE8juPCqSa+C6JxsRbQBzHoG2Tqw6yg/YXKknewV7w8ZpLzXAKYWW3RoJuAfdULCUnZQ7q6qHzWLOcM3iGy24JHA8UngpJ4H/AMbUKgo9BSySl+o5KrDJ4CPwmPTb0qKNaLpX5yPUTPlQDF4t3DuutlZJbWpJsCkwSJA3AMTvWjDdIJErRbmkyLdhvxouQNyGZnpJiW9ySO0BQ9NvGjGX/wBITqd7j7pkeSpFK+DxCHhKDPgQfWrF4YK3APbx896FpMNM6Lg/6Q0H3gk98oP8Qkf9NLvTnpE1iy37NJSpGrUTpvOmIIMkCDvG9KysHGyiPUet/WoNML1HUUkQIiRxMyDS9iXISYa6PfX8PnR1KqX8oRZXePnRZGHfUkqbRrAISeskQSCR7x7DSZvkdFcH/9k="
                    Rating=4,
                    OpeningHours = new List<OpeningTime>() { new OpeningTime() { OpenHour="06:00", CloseHour="23:00" } },
                    Amenities = new List<Amenity>() { Amenity.Alcohol, Amenity.Food, Amenity.Printing, Amenity.Showers, Amenity.Wifi },
                    AmenitiesDescriptions = GetAmenitiies(new List<Amenity>() { Amenity.Alcohol, Amenity.Food, Amenity.Printing, Amenity.Showers, Amenity.Wifi } )
                },
                new Lounge
                {
                    Id = 3,
                    Title = "Etihad Airways First And Business Class Lounge",
                    Description="The House is the home of jet set lounging - take a seat and enjoy the atmosphere. Entry to The House includes: White linen, à la carte dining with waiter service,Award-winning sparkling wines, classic cocktails & craft beer, Barista coffee, speciality teas and freshly-made smoothies & juices, Unlimited WiFi, quality newspapers and glossy magazines, Shower facilities,Unlimited WiFi, newspapers and magazines",
                    Terminal="T1",
                    Directions="",
                    ImageUrl="",
                    Rating=5,
                    OpeningHours = new List<OpeningTime>() { new OpeningTime() { OpenHour="05:30", CloseHour="23:00" } },
                    Amenities = new List<Amenity>() { Amenity.Alcohol, Amenity.Food, Amenity.Printing, Amenity.Showers, Amenity.Wifi },
                    AmenitiesDescriptions = GetAmenitiies(new List<Amenity>() { Amenity.Alcohol, Amenity.Food, Amenity.Printing, Amenity.Showers, Amenity.Wifi } )
                }
            };
        }

        private IEnumerable<string> GetAmenitiies(List<Amenity> ameneites) 
        {
            var list = new List<string>();

            foreach (var item in ameneites)
            {
                Amenity enumDisplayStatus = (Amenity)item;
                string stringValue = enumDisplayStatus.ToString();
                list.Add(stringValue);
            }

            return list;

        }
    }

    public interface ILoungeSearchService
    {
        IEnumerable<Lounge> GetSearchResults(SearchRequest searchRequest);
        Lounge GetById(int loungeId);
    }
}
