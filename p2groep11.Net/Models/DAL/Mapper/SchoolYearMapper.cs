using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL.Mapper
{
    public class SchoolYearMapper : EntityTypeConfiguration<SchoolYear>
    {
        public SchoolYearMapper()
        {
            ToTable("SchoolYears");

            // Primary key
            HasKey(c => c.Year);

            // Properties
            this.Property(c => c.Year).HasColumnName("YearInt");

            //Relations
        }
    }
}