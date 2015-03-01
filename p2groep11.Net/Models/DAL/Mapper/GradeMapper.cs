using p2groep11.Net.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace p2groep11.Net.Models.DAL.Mapper
{
    public class GradeMapper : EntityTypeConfiguration<Grade>
    {
        public GradeMapper()
        {
            ToTable("Grades");

            // Primary key
            HasKey(c => c.GradeInt);

            // Properties

            //Relations
            this.HasMany(c => c.SchoolYearProp).WithRequired(c => c.GradeProp).Map(m => m.MapKey("GradeInt")).WillCascadeOnDelete(true);
            this.HasRequired(c => c.DeterminateTableProp);
            this.HasMany(c => c.ContinentProp);
        }
    }
}