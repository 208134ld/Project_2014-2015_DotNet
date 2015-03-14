using System;
using System.Collections.Generic;

namespace p2groep11.Net.Models.Domain
{
    public class Result : ClauseComponent
    {
        public String Vegetatiekenmerk { get; set; }
        public String Klimaatkenmerk { get; set; }

        public Result(String km, String vk)
        {
            this.Klimaatkenmerk = km;
            this.Vegetatiekenmerk = vk;
        }

        public Result()
        {
            
        }

        public override string[] Determinate(ClimateChart chart)
        {
            return new string[] { Klimaatkenmerk, Vegetatiekenmerk };
        }

        public override void CorrectPath(ClimateChart chart, List<ClauseComponent> cp)
        {
            cp.Add(this);
        }

        public override String GetHtmlCode(Boolean isYes)
        {
            if(isYes)
                return "<li><span class='YesSpan'><span class='glyphicon glyphicon-ok'>" + " " +Klimaatkenmerk + "</span></span></li>";
            else
            {
                return "<li><span class='NoSpan'><span class='glyphicon glyphicon-remove'>" + " " + Klimaatkenmerk + "</span></li>";
            }
        }
    }
}
