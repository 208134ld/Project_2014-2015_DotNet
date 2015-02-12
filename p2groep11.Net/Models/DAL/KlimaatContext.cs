using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace p2groep11.Net.Models.DAL
{
    public class KlimaatContext : DbContext
    {
        public KlimaatContext()
            : base("Klimaat")
        {

        }

        public static KlimaatContext Create()
        {
            return new KlimaatContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}