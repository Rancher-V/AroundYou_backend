using AroudYou.Core;
using AroudYou.External;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace AroudYou.Models
{
    public class SearchModel
    {
        DBModel dBModel;
        public SearchModel(IUnitOfWork context)
        {
            dBModel = new DBModel(context);
        }

        public async Task<JArray> search(double lat, double lon, string term, int radius) {
            IExternalAPI api = ExternalAPIFactory.generate();
            JArray events = await api.Search(lat, lon, term, radius);
            dBModel.SaveItemList(events);
            return events;
        }

        


    }
}
