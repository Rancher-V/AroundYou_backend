using AroudYou.Core.Domain;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.External
{
    public interface IExternalAPI
    {
        //IList<Item> Search(double lat, double lon, string term, int radius);
        Task<JArray> Search(double lat, double lon, string term, int radius);
    }
}
