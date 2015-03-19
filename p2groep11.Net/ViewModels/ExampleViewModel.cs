using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.ViewModels
{
    public class ExampleViewModel
    {
        public String Html { get; private set; }

        public ExampleViewModel()
        { 
           Parameter tw = new TW("Wat is de temperatuur van de warmste maand (TW)?");
           ClauseComponent tw10 = new Clause("Is appel een fruit?", tw, "<=", 10);
           ClauseComponent res1 = new Result("Appel is een fruit", "geen woestijn");
           ClauseComponent res2 = new Result("Appel is geen fruit", "woestijn");
           tw10.Add(true, res1);
           tw10.Add(false, res2);
           Html = tw10.GetHtmlCode(true);
        }
    }
}