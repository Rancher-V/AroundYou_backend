using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.External
{
    public class ExternalAPIFactory
    {
        private static readonly string defaultAPI = "ticketmaster";     //setting in config file

        public static IExternalAPI generate(string type)
        {
            switch (type)
            {
                case "restaurant":
                    //return new YelpAPI()
                    return null;
                case "job":
                    return null;
                case "ticketmaster":
                    return new TicketMasterAPI();
                default:
                    throw new ArgumentException("Invalid pipeline " + type);
            }
        }

        public static IExternalAPI generate()
        {
            return generate(defaultAPI);
        }

    }
}
