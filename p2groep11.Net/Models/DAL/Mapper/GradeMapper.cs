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
            HasKey(c => c.GradeId);

            // Properties
            Property(c => c.GradeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(g => g.name).IsRequired();

            //Relations
            HasRequired(c => c.DeterminateTableProp);
            HasMany(c => c.ContinentProp).WithRequired(c => c.GradeId).Map(m => m.MapKey("GradeId")).WillCascadeOnDelete(true);
        }
    }
}