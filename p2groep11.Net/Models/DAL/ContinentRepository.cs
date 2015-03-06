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
            //return continents.Include(l => l.Countries).OrderBy(c => c.Name);
            return continents.OrderBy(c => c.Name);
        }

        public Continent FindById(int continentId)
        {
            
            return continents.Include(l => l.Countries.Select(c=>c.ClimateCharts.Select(mon=>mon.Months))).FirstOrDefault(c => c.ContinentID == continentId); 
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