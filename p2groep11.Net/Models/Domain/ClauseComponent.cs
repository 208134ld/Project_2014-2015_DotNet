using System;

namespace p2groep11.Net.Models.Domain
{
    public abstract class ClauseComponent
    {
        public int ClauseComponentId { get; set; }
        public abstract string Determinate(ClimateChart chart);

        public abstract String GetHtmlCode(Boolean isYes);
        public virtual void Add(Boolean soort, ClauseComponent component)
        {
            throw new ApplicationException();
        }

        public virtual String GetName()
        {
            throw new ApplicationException();
        }

        public virtual ClauseComponent GetYesClause()
        {
            throw new ApplicationException();
        }

        public virtual ClauseComponent GetNoClause()
        {
            throw new ApplicationException();
        }

        public virtual ClauseComponent GetChild()
        {
            throw new ApplicationException();
        }

        public virtual String GetVegetatiekenmerk()
        {
            throw new ApplicationException();
        }

        public virtual String GetKlimaatkenmerk()
        {
            throw new ApplicationException();
        }
       


    }
}
