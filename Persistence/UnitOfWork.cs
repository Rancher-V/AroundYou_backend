using AroudYou.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AroudYou.Core.Repositories;
using AroudYou.Persistence.Repositories;

namespace AroudYou.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AroundContext _context;

        public UnitOfWork(AroundContext context)
        {
            _context = context;
            Items = new ItemRepository(_context);
            Favorites = new FavoriteRepository(_context);
            Users = new UserRepository(_context);
            Categories = new CategoryRepository(_context);
        }


        public IItemRepository Items { get; set; }
        public IFavoriteRepository Favorites { get; set ; }
        public IUserRepository Users { get; set; }
        public ICategoryRepository Categories { get; set; }
       
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
