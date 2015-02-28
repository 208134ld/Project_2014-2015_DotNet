using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL.Mapper
{
    public class ClauseComponentsMapper : EntityTypeConfiguration<ClauseComponent>
    {
        public ClauseComponentsMapper()
        {
            ToTable("ClauseComponents");

            // Primary key
            HasKey(c => c.ClauseComponentId);

            // Properties
            Property(c => c.ClauseComponentId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            

            //Relations
            //HasMany(c => c.Months);
            //HasRequired(c => c.DeterminateTable);
        }
    }
}