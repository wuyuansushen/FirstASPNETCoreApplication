﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fist_ASP.NET_Core_Project.Persistence.Model
{
        public partial struct Country
        {
            public string CountryCode { get; set; }
            public string CountryName { get; set; }
            public string CurrencyCode { get; set; }
            public string Population { get; set; }
            public string Capital { get; set; }
            public string ContinentName { get; set; }
            public string Continent { get; set; }
            public string AreaInSqKm { get; set; }
            public string Languages { get; set; }
            public string GeonameId { get; set; }
        }
}
