using System;
using System.Collections.Generic;
using System.Linq;

namespace p2groep11.Net.Models.Domain
{
    public class Clause : ClauseComponent
    {
        
        public virtual ClauseComponent YesClause { get; set; }
        public virtual ClauseComponent NoClause { get; set; }
        public String Name { get; private set; }

        public virtual Parameter Par1 { get; set; }
        public virtual Parameter Par2 { get; set; }
        public int Waarde { get; set; }
        public String Operator { get; set; }

        public Clause()
        {
        }

        public Clause(String name, Parameter par1, String op, int waarde)
        {
            this.Name = name;
            this.Par1 = par1;
            this.Operator = op;
            this.Waarde = waarde;
        }

        public Clause(String name, Parameter par1, Parameter par2)
        {
            this.Name = name;
            this.Par1 = par1;
            this.Par2 = par2;
        }

        public override String GetHtmlCode(Boolean isYes)
        {
            String html = "";
            if(isYes)
                html += "<li><span class='YesSpan'><span class='glyphicon glyphicon-ok'>" + " "+Name + "</span></span><ul> \n";
            else
            {
                html += "<li><span class='NoSpan'><span class='glyphicon glyphicon-remove'>" + " " + Name + "</span></span><ul> \n";
            }
            html += YesClause.GetHtmlCode(true) + "\n" +
            NoClause.GetHtmlCode(false) + "\n</ul></li>";

            return html;
        }

        public override void Add(Boolean soort, ClauseComponent component)
        {
            if (soort)
            {
                YesClause = component;
            }
            else
            {
                NoClause = component;
            }
        }

        public override string[] Determinate(ClimateChart chart)
        {
            switch (Operator)
            {
                case "<=": return (DeterminateWithOperator(chart) ? YesClause.Determinate(chart) : NoClause.Determinate(chart));
                case "<": return (DeterminateWithOperator(chart) ? YesClause.Determinate(chart) : NoClause.Determinate(chart));
                case ">=": return (DeterminateWithOperator(chart) ? YesClause.Determinate(chart) : NoClause.Determinate(chart));
                default: return (DeterminateWithOperator(chart) ? YesClause.Determinate(chart) : NoClause.Determinate(chart));
            }
        }

        public bool DeterminateWithOperator(ClimateChart chart)
        {
            if (Par2 != null)
            {
                switch (Operator)
                {
                    case "<=": return (Par1.Execute(chart) <= Par2.Execute(chart));
                    case "<": return (Par1.Execute(chart) < Par2.Execute(chart));
                    case ">=": return (Par1.Execute(chart) >= Par2.Execute(chart));
                    case ">": return (Par1.Execute(chart) > Par2.Execute(chart));
                }
            }
            switch (Operator)
            {
                case "<=": return (Par1.Execute(chart) <= Waarde);
                case "<": return (Par1.Execute(chart) < Waarde);
                case ">=": return (Par1.Execute(chart) >= Waarde);
                default: return (Par1.Execute(chart) > Waarde);
            }
        }

        public override List<ClauseComponent> GiveCorrectPath(ClimateChart chart)
        {
            List<ClauseComponent> cp;
            if (DeterminateWithOperator(chart))
            {
                cp = YesClause.GiveCorrectPath(chart);
                cp.Add(this);
                return cp;
            }
            cp = NoClause.GiveCorrectPath(chart);
            cp.Add(this);
            return cp; 
        }
    }
}
