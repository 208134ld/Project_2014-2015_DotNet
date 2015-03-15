using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL.Mapper
{
    public class DeterminateTableMapper : EntityTypeConfiguration<DeterminateTable>
    {
        public DeterminateTableMapper()
        {
            ToTable("DeterminateTable");

            // Primary key
            HasKey(c => c.DeterminateTableId);

            // Properties
            Property(c => c.DeterminateTableId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            //relations
            //HasRequired(d => d.ClauseComponent);
            HasMany(c => c.AllClauseComponents).WithRequired(c => c.DTable).Map(m => m.MapKey("DeterminateTableId")).WillCascadeOnDelete(false);
        }
    }
}