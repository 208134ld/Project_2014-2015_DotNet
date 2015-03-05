using p2groep11.Net.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            Property(c => c.GradeInt).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Relations
            this.HasRequired(c => c.DeterminateTableProp);
            //this.HasMany(c => c.ContinentProp);
        }
    }
}