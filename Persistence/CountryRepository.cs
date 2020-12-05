using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fist_ASP.NET_Core_Project.Persistence.Abstraction;
using fist_ASP.NET_Core_Project.Persistence.Model;
using System.IO;
using System.Text.Json;

namespace fist_ASP.NET_Core_Project.Persistence
{
    public class CountryRepository:ICountryRepository
    {
        private static IList<Country> _countries;
        //Make _countries Queryable
        public IQueryable<Country> ALL()
        {
            EnsureCountriesAreLoaded();
            return _countries.AsQueryable();
        }
        Country Find(string code)
        {
            return (from c in ALL()
                    where c.CountryCode.Equals(code, StringComparison.CurrentCultureIgnoreCase)
                    select c).FirstOrDefault();
        }

        //Filter Fist cases
        IQueryable<Country> AllBy(string filter)
        {
            var normalized = filter.ToLower();
            return String.IsNullOrEmpty(filter) ? ALL() : (ALL().Where(output => output.CountryName.ToLower().StartsWith(filter)));
        }

        #region PRIVATE
        //This is startup.
        private static IList<Country> LoadCountriesFile()
        {
            var json = File.ReadAllText("../Countries.json");
            var countries = JsonSerializer.Deserialize<Country[]>(json);
            return countries.OrderBy(c => c.CountryName).ToList();
        }

        //Check _countries is null
        private static void EnsureCountriesAreLoaded()
        {
            if (_countries == null)
                _countries = LoadCountriesFile();
        }
        #endregion
    }
}
