using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using p2groep11.Net.Models.DAL.Mapper;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
            : base("HOGENT1415_11")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ClimateChart> ClimateCharts { get; set; }
        public DbSet<Month> Months { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ContinentMapper());
            modelBuilder.Configurations.Add(new CountryMapper());
            modelBuilder.Configurations.Add(new ClimateChartMapper());
            modelBuilder.Configurations.Add(new MonthMapper());
        }
    }
}