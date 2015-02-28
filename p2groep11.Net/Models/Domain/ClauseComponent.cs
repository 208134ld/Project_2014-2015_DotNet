using System;

namespace p2groep11.Net.Models.Domain
{
    public abstract class ClauseComponent
    {
        public int ClauseComponentId { get; set; }
        public abstract string Determinate(ClimateChart chart);

        public virtual void Add(Boolean soort, ClauseComponent component)
        {
            throw new NotImplementedException();
        }

        public virtual String GetName()
        {
            throw new NotImplementedException();
        }

        public virtual ClauseComponent GetYesClause()
        {
            throw new NotImplementedException();
        }

        public virtual ClauseComponent GetChild()
        {
            throw new NotImplementedException();
        }

    }
}
