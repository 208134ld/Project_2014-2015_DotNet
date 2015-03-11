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
        private int Waarde { get; set; }

        public Clause()
        {

        }

        public Clause(String name, Parameter par1, int waarde)
        {
            this.Name = name;
            this.Par1 = par1;
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
            html += "<li><span class='YesSpan'>" + Name + "</span><ul> \n";
            else
            {
                html += "<li><span class='NoSpan'>" + Name + "</span><ul> \n";
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

        public override string[] Determinate(ClimateChart chart, List<String> correctPath)
        {
            correctPath.Add(Name);
            return Par1.Execute(chart) <= Waarde ? YesClause.Determinate(chart, correctPath) : NoClause.Determinate(chart, correctPath);
        }
    }
}
