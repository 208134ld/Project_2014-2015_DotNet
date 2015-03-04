using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.ViewModels
{
    public class CountryListViewModel
    {
        public String Name { get; set; }
        public int CountryId { get; set; }
        public int ContinentId { get; set; }
        public CountryListViewModel(Country c)
        {
            Name = c.Name;
            CountryId = c.CountryID;
            ContinentId = c.Continent.ContinentID;
        }

        public CountryListViewModel()
        {
            
        }
    }
}