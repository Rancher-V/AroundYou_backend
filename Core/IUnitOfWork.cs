using AroudYou.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository Items { get; }
        IFavoriteRepository Favorites { get; set; }
        IUserRepository Users { get; set; }
        ICategoryRepository Categories { get; }
        int Complete();
    }
}
