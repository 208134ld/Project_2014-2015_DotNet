using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep11.Net.Models.Domain
{
    public class Country
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
        public Continent Continent { get; set; }

        public virtual ICollection<ClimateChart> ClimateCharts { get; set; }


        public Country()
        {
            ClimateCharts = new List<ClimateChart>();
        }
    }
}
