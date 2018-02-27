using AroudYou.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AroudYou.Core.Repositories;
using AroudYou.Persistence.Repositories;
using AroudYou.Core.Domain;

namespace AroudYou.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AroundContext _context;

        public UnitOfWork(AroundContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
            Items = new ItemRepository(_context);            
            Favorites = new FavoriteRepository(_context);
            Users = new UserRepository(_context);
            Categories = new CategoryRepository(_context);
            ItemCategories = new ItemCategoryRepository(_context);
        }


        public IItemRepository Items { get; set; }
        public IFavoriteRepository Favorites { get; set ; }
        public IUserRepository Users { get; set; }
        public ICategoryRepository Categories { get; set; }

        public IItemCategoryRepository ItemCategories { get; set; }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void AddCategory(Category category) {
            Categories.Add(category);
        }

        public void AddUser(User user) {
            Users.Add(user);
        }

        public void AddFavorite(Favorite favorite) {
            Favorites.Add(favorite);
        }
        public void AddItemCategory(ItemCategory itemCategory) {
            ItemCategories.Add(itemCategory);
        }


        public void Recreate()
        {
            Categories.RemoveRange(_context.Categories);
            Users.RemoveRange(_context.Users);
            Items.RemoveRange(_context.Items);
            Favorites.RemoveRange(_context.Favorites);
            ItemCategories.RemoveRange(_context.ItemCategories);
            Complete();
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }



    }
}
