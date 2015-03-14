using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;
using WebGrease.Css.Extensions;

namespace p2groep11.Net.Models.DAL
{
    public class GradeRepository : IGradeRepository
    {
        private ProjectContext context;
        private DbSet<Grade> grades;

        public GradeRepository(ProjectContext context)
        {
            this.context = context;
            grades = context.Grades;
        }

        public IQueryable<Grade> FindAll()
        {
            return grades.OrderBy(g => g.GradeId); 
        }

        public Grade FindById(int gradeId)
        {
            return grades.Include(l => l.DeterminateTableProp.ClauseComponent).FirstOrDefault(g => g.GradeId == gradeId);         
        }

        public Grade FindBySchoolyear(int schoolyear)
        {
            return grades.FirstOrDefault(g => g.SchoolYears.Select(s => s.Year).Contains(schoolyear));
        }

        public ICollection<Continent> GetContinents(int schoolyear)
        {
            return FindBySchoolyear(schoolyear).Continents;
        }

        public ICollection<Country> GetCountries(int schoolyear, int continentId)
        {
            return GetContinents(schoolyear).FirstOrDefault(c => c.ContinentID == continentId).Countries;
        }

        public ICollection<ClimateChart> GetClimateCharts(int schoolyear, int continentId, int countryId)
        {
            return GetCountries(schoolyear, continentId).FirstOrDefault(c => c.CountryID == countryId).ClimateCharts;
        }

        public ClimateChart GetClimateChartByClimateChartId(int schoolyear, int continentId, int countryId, int climateChartId)
        {
            return
                GetClimateCharts(schoolyear, continentId, countryId)
                    .FirstOrDefault(c => c.ClimateChartID == climateChartId);
        }

        public void Remove(Grade grade)
        {
            grades.Remove(grade);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        
    }
}