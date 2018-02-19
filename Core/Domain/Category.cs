using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Core.Domain
{
    public class Category
    {
        public Category()
        {
            ItemCategories = new HashSet<ItemCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ItemCategory> ItemCategories { get; set; }
    }
}
