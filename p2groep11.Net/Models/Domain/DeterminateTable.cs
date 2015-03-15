using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Notifications;

namespace p2groep11.Net.Models.Domain
{
    public class DeterminateTable
    {
        public int DeterminateTableId { get; set; }
        public ClauseComponent ClauseComponent { get; set; }
        public virtual ICollection<ClauseComponent> AllClauseComponents { get; set; }
         


        public DeterminateTable(ClauseComponent component)
        {
            AllClauseComponents = new List<ClauseComponent>();
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