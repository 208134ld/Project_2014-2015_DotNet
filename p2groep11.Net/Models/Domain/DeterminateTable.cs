using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2groep11.Net.Models.Domain
{
    public class DeterminateTable
    {
        public int DeterminateTableId { get; set; }
        public virtual ClauseComponent ClauseComponent { get; set; }
         


        public DeterminateTable(ClauseComponent component)
        {
            this.ClauseComponent = component;
        }



        public DeterminateTable()
        {

        }

        public String[] Determinate(ClimateChart chart)
        {
            return ClauseComponent.Determinate(chart);
        }

        public List<ClauseComponent> CorrectPath(ClimateChart chart)
        {
            List<ClauseComponent> cp = new List<ClauseComponent>();
            ClauseComponent.CorrectPath(chart, cp);
            return cp;
        }
        

    }
}