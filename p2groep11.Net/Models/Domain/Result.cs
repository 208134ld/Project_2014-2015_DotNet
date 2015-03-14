using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace p2groep11.Net.Models.Domain
{
    public class Result : ClauseComponent
    {
        public String Vegetationfeature { get; set; }
        public String Climatefeature { get; set; }
        public byte[] VegetationPicture { get; set; }

        public Result(String km, String vk, byte[] image)
        {
            Climatefeature = km;
            Vegetationfeature = vk;
            VegetationPicture = image;
        }

        public Result()
        {
            
        }

        public override string[] Determinate(ClimateChart chart)
        {
            return new string[] { Climatefeature, Vegetationfeature };
        }

        public override void CorrectPath(ClimateChart chart, List<ClauseComponent> cp)
        {
            cp.Add(this);
        }

        public override String GetHtmlCode(Boolean isYes)
        {
            if(isYes)
            return "<li><span class='YesSpan'>" + Climatefeature + "</span></li>";
            else
            {
                return "<li><span class='NoSpan'>" + Vegetationfeature + "</span></li>";
            }
        }

        public Image byteArrayToImage()
        {
            Image returnImage = null;
            MemoryStream ms = new MemoryStream(VegetationPicture);
            returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
