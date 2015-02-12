using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace p2groep11.Net.Models.DAL
{
    public class ContinentRepository : IContinentRepository
    {
        private KlimaatContext context;
        private DbSet<Continent> Continenten;

        public ContinentRepository(KlimaatContext context)
        {
            this.context = context;
            Continenten = this.context.Continenten;
        }

        public void Remove(Continent continent)
        {
            Continenten.Remove(continent);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public Continent FindById(int continentId)
        {
            return Continenten.Find(continentId);
        }
    }
}