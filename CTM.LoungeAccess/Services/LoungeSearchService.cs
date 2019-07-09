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

                },
                new Lounge
                {

                },
                new Lounge
                {

                },
                new Lounge
                {

                }
            };

        }
    }

    public interface ILoungeAccessService
    {

    }
}
