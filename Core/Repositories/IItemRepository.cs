using AroudYou.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Core.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        Item GetSingleItemWithFavAndCate(string id);

        IEnumerable<Item> GetItemWithFavAndCate(int pageIndex, int pageSize);



    }
}
