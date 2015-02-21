using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL
{
    public class ContinentRepository : IContinentRepository
    {
        private ProjectContext context;
        private DbSet<Continent> continents;

        public ContinentRepository(ProjectContext context)
        {
            this.context = context;
            continents = context.Continents;
        }

        public IQueryable<Continent> FindAll()
        {
            return continents.OrderBy(c => c.Name);
        }

        public Continent FindById(int continentId)
        {
            return continents.FirstOrDefault(c => c.ContinentID == continentId); 
        }

        public Country FindCountryByID(int continentId, int countryId)
        {
            return
                context.Continents.Include(m => m.Countries)
                    .SingleOrDefault(m => m.ContinentID == continentId)
                    .Countries.FirstOrDefault(co => co.CountryID == countryId);
        }

        public ClimateChart FindClimateChartById(int continentId, int countryId, int climateId)
        {
            return context.Continents.Include(m => m.Countries.Select(cl => cl.ClimateCharts.Select(mon=>mon.Months)))
                .FirstOrDefault(m => m.ContinentID == continentId)
                .Countries.FirstOrDefault(co => co.CountryID == countryId)
                .ClimateCharts.FirstOrDefault(c => c.ClimateChartID == climateId);

        }

        public void Remove(Continent continent)
        {
            continents.Remove(continent);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        
    }
}