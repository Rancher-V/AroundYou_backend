using AroudYou.Core.Domain;
using AroudYou.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Persistence.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(AroundContext context) : base(context)
        {

        }
        public Item GetSingleItemWithFavAndCate(string id)
        {
            return AroundContext.Items          //TODO: add where clause for time to get recent period
                .Include(i => i.Favorites)
                .Include(i => i.ItemCategories)
                .ThenInclude(itemCate => itemCate.Category)
                .SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<Item> GetItemWithFavAndCate(int pageIndex, int pageSize)
        {
            return AroundContext.Items          //TODO: add where clause for time to get recent period
               .Include(i => i.Favorites)
               .Include(i => i.ItemCategories)
               .ThenInclude(itemCate => itemCate.Category)
               .Skip((pageIndex - 1) * pageSize)
               .Take(pageSize)
               .ToList();
        }

        public AroundContext AroundContext
        {
            get { return Context as AroundContext; }
        }

    }
}
