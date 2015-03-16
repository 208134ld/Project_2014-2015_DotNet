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

            //Relations
            HasRequired(g => g.DeterminateTableProp);
            HasMany(g => g.Continents).WithMany(g => g.Grades);
            HasMany(g => g.SchoolYears).WithRequired(g => g.GradeProp);
            HasOptional(g => g.QuestionListProp);
        }
    }
}