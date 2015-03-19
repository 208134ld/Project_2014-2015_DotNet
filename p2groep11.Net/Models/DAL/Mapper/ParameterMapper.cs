using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL.Mapper
{
    public class ParameterMapper : EntityTypeConfiguration<Parameter>
    {
        public ParameterMapper()
        {
            // Primary key
            HasKey(p => p.ParameterId);
            // Properties
            Property(p => p.ParameterId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Beschrijving).IsOptional();

            //Relations

        }
    }
}