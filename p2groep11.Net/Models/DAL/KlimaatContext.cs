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
    public class KlimaatContext : IdentityDbContext<ApplicationUser>
    {
        public StuHoGentContext()
            : base("StuHoGent")
        {

        }
        public DbSet<Werknemer> Werknemers { get; set; }
        public DbSet<Reden> Redenen { get; set; }
        public DbSet<Afwezigheid> Afwezigheden { get; set; }

        public static StuHoGentContext Create()
        {
            return new StuHoGentContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}