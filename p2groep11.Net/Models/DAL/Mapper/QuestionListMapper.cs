using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL.Mapper
{
    public class QuestionListMapper : EntityTypeConfiguration<QuestionList>
    {
        public QuestionListMapper()
        {
            // Primary key
            HasKey(c => c.QuestionListID);

            // Properties
            Property(c => c.QuestionListID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Relations
            HasMany(c => c.Parameters).WithMany().Map(m => m.MapLeftKey("QuestionListId").MapRightKey("ParameterId"));
        }
    }
}