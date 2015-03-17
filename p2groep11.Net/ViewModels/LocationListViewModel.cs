using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.ViewModels
{
    public class LocationListViewModel
    {
        public String Location { get; set; }
        public int CountryID { get; set; }
        public int ContinentID { get; set; }
        public int ClimateChartID { get; set; }
        public double ChartLatitude { get; set; }
        public double ChartLongitude { get; set; }

        public LocationListViewModel(ClimateChart location)
        {
            Location = location.Location;
            CountryID = location.Country.CountryID;
            ContinentID = location.Country.Continent.ContinentID;
            ClimateChartID = location.ClimateChartID;
            ChartLatitude = location.Latitude;
            ChartLongitude = location.Longitude;
        }

        public LocationListViewModel()
        {
            
        }
    }
}