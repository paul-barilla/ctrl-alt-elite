using CTM.LoungeAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.LoungeAccess.Services
{
    public class LoungeSearchService : ILoungeAccessService
    {
        public LoungeSearchService()
        {

        }

        public IEnumerable<Lounge> GetSearchResults()
        {
            return new List<Lounge>()
            {
                new Lounge
                {
                    Id = 1,
                    Title = "Qantas Club Lounge",

                },
                new Lounge
                {
                    Id = 2,
                    Title = "American Express Lounge",
                },
                new Lounge
                {
                    Id = 3,
                    Title = "Etihad Airways First And Business Class Lounge",
                }
            };

        }
    }

    public interface ILoungeAccessService
    {

    }
}
