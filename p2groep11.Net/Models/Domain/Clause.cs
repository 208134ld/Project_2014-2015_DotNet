using System;
using System.Collections.Generic;
using System.Linq;

namespace p2groep11.Net.Models.Domain
{
    public class Clause : ClauseComponent
    {
        public ICollection<ClauseComponent> ClauseComponents { get; set; }
        public override String Name { get; private set; }

        public Clause(String name)
        {
            this.Name = name;
        }

        public override void Add(ClauseComponent clauseComponent)
        {
            ClauseComponents.Add(clauseComponent);
        }

        public override void Remove(ClauseComponent clauseComponent)
        {
            ClauseComponents.Remove(clauseComponent);
        }

        public override ClauseComponent GetChild(int i)
        {
            return (ClauseComponent) ClauseComponents.ElementAt(i);
        }


    }
}
