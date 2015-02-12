using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace p2groep11.Net.Models.DAL.Mapper
{
    public class ContinentMapper : EntityTypeConfiguration<Continent>
    {
        public ContinentMapper
        {
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            ToTable("Continenten");
        }
    }
}