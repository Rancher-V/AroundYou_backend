using AroudYou.Core.Domain;
using AroudYou.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository Items { get; set; }
        IFavoriteRepository Favorites { get; set; }
        IUserRepository Users { get; set; }
        ICategoryRepository Categories { get; set;}
        void Recreate();
        int Complete();
        Task<int> CompleteAsync();
        void AddItem(Item item);
        void AddCategory(Category category);
        void AddUser(User user);
        void AddFavorite(Favorite favorite);
        void AddItemCategory(ItemCategory itemCategory);

    }
}
