using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AroudYou.Services
{
    public interface ISeedDataService
    {
        Task EnsureSeedData();
    }
}
