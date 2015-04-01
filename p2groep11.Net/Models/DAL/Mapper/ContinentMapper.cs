using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL.Mapper
{
    public class ContinentMapper : EntityTypeConfiguration<Continent>
    {
        public ContinentMapper()
        {
            ToTable("Continents");

            // Primary key
            HasKey(c => c.ContinentID);

            // Properties
            Property(c => c.ContinentID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(c => c.Name).IsRequired();

            //Relations
            HasMany(c => c.Countries).WithRequired(c => c.Continent).Map(m => m.MapKey("ContinentID")).WillCascadeOnDelete(true);
        }
    }
}