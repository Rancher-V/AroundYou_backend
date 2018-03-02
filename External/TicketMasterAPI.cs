using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AroudYou.Core.Domain;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using AroudYou.Models;
using Newtonsoft.Json;

namespace AroudYou.External
{
    public class TicketMasterAPI : IExternalAPI
    {
        private static readonly string API_HOST = "app.ticketmaster.com";
        private static readonly string SEARCH_PATH = "/discovery/v2/events.json";
        private static readonly string DEFAULT_TERM = "";  // no restriction
        private static readonly string API_KEY = "gbaCyXHMajj880HmDKHx0hfW2Gt4ofsQ";


        public async Task<JArray> Search(double lat, double lon, string term, int radius)
        {
            string url = $"http://{API_HOST}{SEARCH_PATH}";
            string geoHash = GeoHash.encodeGeohash(lat, lon, 4);
            term = (term == null) ? term : DEFAULT_TERM;
            term = WebUtility.UrlEncode(term);
            string query = $"apikey={API_KEY}&geoPoint={geoHash}&keyword={term}&radius={radius}";
            string baseUrl = url + "?" + query;
            string inputLine = "";
            StringBuilder response = new StringBuilder();

            using (HttpClient client = new HttpClient())
            {
                //Setting up the response...         
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                {
                    //string responseCode = res.ReasonPhrase;
                    //Console.WriteLine(responseCode);
                    using (HttpContent content = res.Content)
                    {
                        using (StreamReader sr = new StreamReader(await content.ReadAsStreamAsync()))
                        {
                            while ((inputLine = sr.ReadLine()) != null)
                            {
                                response.Append(inputLine);
                            }
                        }
                    }
                }
            }

            JObject responseJson = JObject.Parse(response.ToString());
            if (responseJson["_embedded"] == null)
            {
                return new JArray();
            }
            JArray rawJson = (JArray)responseJson["_embedded"]["events"];
            string resSearch = JsonConvert.SerializeObject(GetItemList(rawJson), Formatting.Indented);
            
            return JArray.Parse(resSearch);

        }

        private IList<ItemModel> GetItemList(JArray events)
        {
            IList<ItemModel> itemList = new List<ItemModel>();
            ItemModel item = new ItemModel();
            try
            {
                foreach (JObject e in events)
                {
                    item.Id = GetStringFieldOrNull(e, "id");
                    item.Name = GetStringFieldOrNull(e, "name");
                    item.Url = GetStringFieldOrNull(e, "url");
                    item.Description = GetDescription(e);
                    item.Categories = GetCategories(e);
                    item.ImageUrl = GetImageUrl(e);
                    JObject venue = GetVenue(e);
                    
                    if (venue != null)  
                    {   
                        if (venue["address"] != null)
                        {
                            JObject address = (JObject)venue["address"];
                            StringBuilder sb = new StringBuilder();
                            if (address["line1"] != null)
                            {
                                sb.Append(address["line1"]);
                            }
                            if (address["line2"] != null)
                            {
                                sb.Append(address["line2"]);
                            }
                            if (address["line3"] != null)
                            {
                                sb.Append(address["line3"]);
                            }
                            item.Address = sb.ToString();
                        }
                        if (venue["city"] != null)
                        {
                            JObject city = (JObject)venue["city"];
                            item.City = GetStringFieldOrNull(city, "name");
                        }
                        if (venue["country"] != null)
                        {
                            JObject country = (JObject)venue["country"];
                            item.Country = GetStringFieldOrNull(country, "name");
                        }
                        if (venue["state"] != null)
                        {
                            JObject state = (JObject)venue["state"];
                            item.State = GetStringFieldOrNull(state, "name");
                        }
                        item.Zipcode = GetStringFieldOrNull(venue, "postalCode");
                        if (venue["location"] != null)
                        {
                            JObject location = (JObject)venue["location"];
                            item.Latitude = GetNumericFieldOrNull(location, "latitude");
                            item.Longitude = GetNumericFieldOrNull(location, "longitude");
                        }
                    }
                    itemList.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemList;
        }

        private string GetStringFieldOrNull(JObject Event, string filed) 
        {
            try
            {
                return Event[filed] == null ? null : Event[filed].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private string GetDescription(JObject Event)
        {
            try
            {
                if (Event["description"] != null)
                {
                    return Event["description"].ToString();
                }
                else if (Event["additionalInfo"] != null)
                {
                    return Event["additionalInfo"].ToString();
                }
                else if (Event["info"] != null)
                {
                    return Event["info"].ToString();
                }
                else if (Event["pleaseNote"] != null)
                {
                    return Event["pleaseNote"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
		    return null;
        }

        private ISet<string> GetCategories(JObject Event)
        {
            ISet<string> categories = new HashSet<string>();
            if (Event["classifications"] != null) {
                JArray classifications = (JArray)Event["classifications"];
                foreach(JObject classification in classifications )
                if (classification["segment"] != null)
                {
                    JObject segment = (JObject)classification["segment"];
                    string category = GetStringFieldOrNull(segment, "name");
                    categories.Add(category);
                }
            }
		    return categories;
        }

        // Get first image url from an event object
        private string GetImageUrl(JObject Event)
        {
            if (Event["images"] != null) 
            {
                JArray imageArray = (JArray)Event["images"];
                if (imageArray.Count >= 1)
                {
                    return GetStringFieldOrNull((JObject)imageArray.FirstOrDefault(), "url");
                }
            }
		    return null;
        }





        // return the first venue of an event object
        private JObject GetVenue(JObject Event) 
        {
            if (Event["_embedded"] != null) {
                JObject embedded = (JObject)Event["_embedded"];
                if (embedded["venues"] != null)
                {
                    JArray venues = (JArray)embedded["venues"];
                    if (venues.Count >= 1)
                    {
                        return (JObject)venues.FirstOrDefault();
                    }
                }
            }
		    return null;
        }

        private float GetNumericFieldOrNull(JObject Event, string field)
        {
            try
            {
                return Event[field] == null ? 0.0f : float.Parse(Event[field].ToString());
            }
            catch (Exception)
            {
                throw;
            }   
        }
    }
}
