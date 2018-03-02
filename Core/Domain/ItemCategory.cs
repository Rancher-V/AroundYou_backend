using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Core.Domain
{
    public class Categories
    {
        public Categories(Item Item, Category Category)
        {
            this.Item = Item;
            this.Category = Category;
        }
        public Categories()
        {

        }

        public string ItemId { get; set; }
        public Item Item { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
