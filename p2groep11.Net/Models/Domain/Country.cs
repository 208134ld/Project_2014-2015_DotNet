using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;

namespace p2groep11.Net.Models.Domain
{
    public class Country
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
        public virtual Continent Continent { get; set; }
        public virtual ICollection<ClimateChart> ClimateCharts { get; set; }

        public Country()
        {
            ClimateCharts = new List<ClimateChart>();
        }

        public Country(String name, Continent c)
        {
            Name = name;
            Continent = c;
            ClimateCharts = new List<ClimateChart>();
        }

        public Country(String name)
        {
            Name = name;
            ClimateCharts = new List<ClimateChart>();
        }

        public Country(String name, int id)
        {
            Name = name;
            ClimateCharts = new List<ClimateChart>();
            CountryID = id;
        }

        public ClimateChart GetClimateChart(int climateChartID )
        {
            ClimateChart c =ClimateCharts.FirstOrDefault(cl => cl.ClimateChartID == climateChartID);
            if (c != null)
                return c;
            else throw new ArgumentNullException("ClimateChart met " + climateChartID + " not found");
        }
    }
}
