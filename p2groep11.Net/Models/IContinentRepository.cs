using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models
{
    public interface IContinentRepository
    {
        IQueryable<Continent> FindAll();
        Continent FindById(int continentId);
        Country FindCountryByID(int continentId, int countryId);
        ClimateChart FindClimateChartById(int continentId, int countryId, int climateId);
        void Remove(Continent continent);
        void SaveChanges();      
    }
}
