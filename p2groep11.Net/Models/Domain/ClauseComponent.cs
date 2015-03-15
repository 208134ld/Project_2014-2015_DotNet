using System;
using System.Collections.Generic;

namespace p2groep11.Net.Models.Domain
{
    public abstract class ClauseComponent
    {
        public int ClauseComponentId { get; set; }
        public abstract string[] Determinate(ClimateChart chart);
        public abstract void CorrectPath(ClimateChart chart, List<ClauseComponent> cp);
        public virtual DeterminateTable DTable { get; set; }

        public abstract String GetHtmlCode(Boolean isYes);
        public virtual void Add(Boolean soort, ClauseComponent component)
        {
            throw new ApplicationException();
        }

        public ClauseComponent()
        {
            
        }
    }
}
