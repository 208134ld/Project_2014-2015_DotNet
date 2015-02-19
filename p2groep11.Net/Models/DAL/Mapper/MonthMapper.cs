using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL.Mapper
{
    public class MonthMapper : EntityTypeConfiguration<Month>
    {
        public MonthMapper()
        {
            ToTable("Months");

            // Primary key
            HasKey(c => c.MonthID);

            // Properties
            Property(c => c.MonthID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.month).IsRequired();
            Property(c => c.AverTemp).IsRequired();
            Property(c => c.Sediment).IsRequired();

            // Relations

        }
    }
}