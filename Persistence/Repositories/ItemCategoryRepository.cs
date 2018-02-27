using AroudYou.Core.Domain;
using AroudYou.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Persistence.Repositories
{
    public class ItemCategoryRepository : Repository<ItemCategory>, IItemCategoryRepository
    {
        public ItemCategoryRepository(AroundContext context) : base(context)
        {
        }

        public AroundContext AroundContext
        {
            get { return Context as AroundContext; }
        }


    }
}
