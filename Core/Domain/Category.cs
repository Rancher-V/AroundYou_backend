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
            ItemCategories = new HashSet<Categories>();
        }

        public Category(String name)
        {
            ItemCategories = new HashSet<Categories>();
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Categories> ItemCategories { get; set; }
    }
}
