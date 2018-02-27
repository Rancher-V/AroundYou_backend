using AroudYou.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryWithItems(int id);



    }
}
