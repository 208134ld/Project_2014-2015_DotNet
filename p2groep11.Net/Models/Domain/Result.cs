using System;

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

        public override string Determinate(ClimateChart chart)
        {
            return "Klimaatkenmerk: " + Klimaatkenmerk + ". Vegetatiekenmerk: " + Vegetatiekenmerk + ".";
        }

        public override String GetHtmlCode(Boolean isYes)
        {
            if(isYes)
            return "<li><span class='YesSpan'>" + Klimaatkenmerk + "</span></li>";
            else
            {
                return "<li><span class='NoSpan'>" + Klimaatkenmerk + "</span></li>";
            }
        }


        public override String GetVegetatiekenmerk()
        {
            return this.Vegetatiekenmerk;
        }

        public override String GetKlimaatkenmerk()
        {
            return this.Klimaatkenmerk;
        }
    }
}
