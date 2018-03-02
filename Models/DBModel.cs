using AroudYou.Core;
using AroudYou.Core.Domain;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Models
{
    public class DBModel
    {
        IUnitOfWork _context;

        public DBModel(IUnitOfWork context)
        {
            _context = context;
        }

        protected Category getCategory(String category)
        {
            Category cate = _context.Categories.SingleOrDefault(c => c.Name == category);
            if (cate == null)
            {
                cate = new Category(category);
                _context.Categories.Add(cate);
            }
            return cate;
        }


        public async void SaveItemList(JArray events)
        {
            
            await _context.CompleteAsync();

        }


    }
}
