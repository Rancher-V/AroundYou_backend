using AroudYou.Core.Domain;
using AroudYou.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Persistence.Repositories
{
    public class FavoriteRepository : Repository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(AroundContext context) : base(context)
        {
        }

        public AroundContext AroundContext
        {
            get { return Context as AroundContext; }
        }


    }
}
