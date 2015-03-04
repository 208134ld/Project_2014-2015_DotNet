using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.ViewModels
{
    public class ContinentsListViewModel
    {
        public String Name { get; set; }
        public int ContinentID { get; set; }
        public ContinentsListViewModel(Continent c)
        {
            Name = c.Name;
            ContinentID = c.ContinentID;
        }

        public ContinentsListViewModel()
        {
            
        }
    }
}