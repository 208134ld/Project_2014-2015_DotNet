using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;
using p2groep11.Net.Models;

namespace p2groep11.Net.Models.Domain
{
    public class Continent
    {
        public int ContinentID { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Grade> Grades { get; set; }

        public virtual ICollection<Country> Countries { get; set; }

        public Continent()
        {
            Grades = new List<Grade>();
            Countries = new List<Country>();
        }

        public Continent(string name)
        {
            Grades = new List<Grade>();
            Countries = new List<Country>();
            Name = name;
        }

        public Country getCountry(int countryID)
        {
           return Countries.FirstOrDefault(c => c.CountryID == countryID);
        }
    }
}
