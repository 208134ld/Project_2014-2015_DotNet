﻿using System;
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

        public IQueryable<Country> FindCountriesByContinentID(int continentId)
        {
            Continent continent = FindById(continentId);
            return continent.Countries.AsQueryable().OrderBy(c => c.Name);
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