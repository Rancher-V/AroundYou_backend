using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Core.Domain
{
    public class User
    {
        public User()
        {
            Favorites = new HashSet<Favorite>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int FavoriteId { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }

    }
}
