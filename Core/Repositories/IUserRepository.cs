using AroudYou.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithFav(int id);
    }
}
