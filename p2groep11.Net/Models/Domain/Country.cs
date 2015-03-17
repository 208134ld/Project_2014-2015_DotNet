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
        //public bool AboveEquator { get; set; }
        //public double Latitude { get; set; }
        //public double Longitude { get; set; }
        public virtual Continent Continent { get; set; }
        public virtual ICollection<ClimateChart> ClimateCharts { get; set; }

        public Country()
        {
            ClimateCharts = new List<ClimateChart>();
            //AboveEquator = true;
        }

        public Country(String name, Continent c)
        {
            Name = name;
            Continent = c;
            ClimateCharts = new List<ClimateChart>();
            //AboveEquator = true;
            //Latitude = 0;
            //Longitude = 0;
        }

        public Country(String name)
        {
            Name = name;
            //Continent = c;
            ClimateCharts = new List<ClimateChart>();
            //Latitude = latitude;
            //Longitude = longitude;
            //AboveEquator = latitude > 0;
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
