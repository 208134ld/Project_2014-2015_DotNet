using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models
{
    public class CountryRepository : ICountryRepository
    {
        public IQueryable<Country> FindAll()
        {
            throw new NotImplementedException();
        }

        public Country FindById(int CountryId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Country country)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}