using System.Collections.Generic;
using System.Linq;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL
{
    public interface IGradeRepository
    {
        IQueryable<Grade> FindAll();
        Grade FindById(int gradeId);
        Grade FindBySchoolyear(int schoolyear);
        ICollection<Continent> GetContinents(int schoolyear);
        ICollection<Country> GetCountries(int schoolyear, int continentId);
        ICollection<ClimateChart> GetClimateCharts(int schoolyear, int continentId, int countryId);
        ClimateChart GetClimateChartByClimateChartId(int schoolyear, int continentId, int countryId, int climateChartId);
        void Remove(Grade grade);
        void SaveChanges();      
    }
}
