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
        private KlimaatContext context;
        private DbSet<Continent> continents;

        public ContinentRepository(KlimaatContext context)
        {
            this.context = context;
            continents = this.context.Continenten;
        }

        public IQueryable<Continent> FindAll()
        {
            return continents.OrderBy(c => c.Name);
        }

        public Continent FindById(int continentId)
        {
            return continents.FirstOrDefault(c => c.ContinentID == continentId); ;
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