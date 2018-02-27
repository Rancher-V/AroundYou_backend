using AroudYou.Core;
using AroudYou.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Services
{
    public class SeedDataService : ISeedDataService
    {
        IUnitOfWork _context;
        public SeedDataService(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            _context.Recreate();
            Item item = new Item();
            item.Name = "have fun";
            item.Id = "abcde";
            item.State = "NJ";
            User user = new User();
            user.FirstName = "YM";
            user.LastName = "X";
            user.Password = "123";
            Category category = new Category();
            category.Name = "Music";
            

            Favorite favorite = new Favorite();
            favorite.Item = item;
            favorite.User = user;
            favorite.LastFavorTime = DateTime.Now;

            ItemCategory ic = new ItemCategory();
            ic.Category = category;
            ic.Item = item;

            _context.AddUser(user);
            _context.AddItem(item);
            _context.AddCategory(category);
            _context.AddFavorite(favorite);
            _context.AddItemCategory(ic);

            await _context.CompleteAsync();
        }
    }
}
