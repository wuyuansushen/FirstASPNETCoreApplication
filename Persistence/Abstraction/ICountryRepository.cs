using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fist_ASP.NET_Core_Project.Persistence.Model;

namespace fist_ASP.NET_Core_Project.Persistence.Abstraction
{
    public interface ICountryRepository
    {
        IQueryable<Country> All();
        Country Find(string code);
        IQueryable<Country> AllBy(string filter);
    }
}
