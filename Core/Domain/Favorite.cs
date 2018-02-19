using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Core.Domain
{
    public class Favorite
    {       
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public DateTime LastFavorTime { get; set; }
        public virtual Item Item { get; set; }
        public virtual User User { get; set; }

    }
}
