using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2groep11.Net.Models.Domain
{
    public class DeterminateTable
    {
        public int DeterminateTableId { get; set; }
        public int GradeId { get; set; }
        public ClauseComponent ClauseComponent { get; set; }

        public DeterminateTable(ClauseComponent component)
        {
            this.ClauseComponent = component;
            this.GradeId = 1;
        }

        public String Determinate(ClimateChart chart)
        {
            return ClauseComponent.Determinate(chart);
        }

        public String Determinate()
        {
            return "hallo";
        }
    }
}