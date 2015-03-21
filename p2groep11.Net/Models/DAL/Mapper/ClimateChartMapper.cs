using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Ninject.Infrastructure.Language;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL.Mapper
{
    public class ClimateChartMapper : EntityTypeConfiguration<ClimateChart>
    {
        public ClimateChartMapper()
        {
            ToTable("ClimateCharts");

            // Primary key
            HasKey(c => c.ClimateChartID);

            // Properties
            Property(c => c.ClimateChartID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Location).IsRequired();
            Property(c => c.BeginPeriod).IsRequired();
            Property(c => c.EndPeriod).IsRequired();
            Property(c => c.AboveEquator).IsRequired();
            Property(c => c.Latitude).IsRequired();
            Property(c => c.Longitude).IsRequired();
            //Property(c => c.TempArray).IsRequired(); WtFFF

            //Relations
            HasMany(c => c.Months).WithMany().Map(m => m.MapLeftKey("ClimateChartId").MapRightKey("MonthId"));
        }
    }
}