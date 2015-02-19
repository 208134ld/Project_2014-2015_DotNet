using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models
{
    interface ICountryRepository
    {
        IQueryable<Country> FindAll();
        Country FindById(int CountryId);
        void Remove(Country country);
        void SaveChanges();  
    }
}
