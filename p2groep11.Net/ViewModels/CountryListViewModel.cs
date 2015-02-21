using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.ViewModels
{
    public class CountryListViewModel
    {
        public IEnumerable<Country> Countries { get; set; }
    }
}