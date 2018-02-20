using AroudYou.Core.Domain;
using AroudYou.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AroundContext context) : base(context)
        {

        }

        public User GetUserWithFav(int id)
        {
            return AroundContext.Users
                .Include(u => u.Favorites)
                .SingleOrDefault(u => u.Id == id);
                                 


        }

        public AroundContext AroundContext
        {
            get { return Context as AroundContext; }
        }
    }
}
