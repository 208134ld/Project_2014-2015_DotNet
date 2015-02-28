using System.Linq;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL
{
    public interface IContinentRepository
    {
        IQueryable<Continent> FindAll();
        Continent FindById(int continentId);
        IQueryable<Country> FindCountriesByContinentID(int continentId);
        IQueryable<ClimateChart> FindLocationsByCountryID(int continentId, int countryId);
        Country FindCountryByID(int continentId, int countryId);
        ClimateChart FindClimateChartById(int continentId, int countryId, int climateId);
        void Remove(Continent continent);
        void SaveChanges();      
    }
}
