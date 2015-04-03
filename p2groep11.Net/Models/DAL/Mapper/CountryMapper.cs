using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL.Mapper
{
    public class CountryMapper : EntityTypeConfiguration<Country>
    {
        public CountryMapper()
        {
            ToTable("Countries");

            // Primary key
            HasKey(c => c.CountryID);

            // Properties
            Property(c => c.CountryID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(c => c.Name).IsRequired();
            

            //Relations
            HasMany(c => c.ClimateCharts).WithRequired(c => c.Country).Map(m => m.MapKey("CountryID")).WillCascadeOnDelete(true);
        }
    }
}