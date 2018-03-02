using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AroudYou.Models;
using Newtonsoft.Json.Linq;
using AroudYou.Core;

namespace AroudYou.Controllers
{
    [Produces("application/json")]
    [Route("api/Search")]
    public class SearchController : Controller
    { 
        SearchModel searchModel;
        public SearchController(IUnitOfWork context)
        {
            searchModel = new SearchModel(context);
        }

        // GET: api/Search
        //exmaple: api/Search?user_id=1111&lat=37.38&lon=-122.08&radius=50
        [HttpGet]
        public async Task<JArray> Get(string user_id, string lat, string lon, string radius, string term)
        {
            double latitude = Convert.ToDouble(lat);
            double longitude = Convert.ToDouble(lon);
            int rad = Convert.ToInt32(radius);
            return await searchModel.search(latitude, longitude, term, rad);
        }

        // GET: api/Search/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        } 
    }
}
