using AroudYou.Core.Domain;
using AroudYou.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace AroudYou.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AroundContext context) : base(context)
        {

        }

        public Category GetCategoryWithItems(int id)
        {
            return AroundContext.Categories
                .Include(cate => cate.ItemCategories)
                .ThenInclude(ItemCategory => ItemCategory.Item)
                .SingleOrDefault(cate => cate.Id == id);
        }

        public AroundContext AroundContext
        {
            get { return Context as AroundContext; }
        }

    }
}
