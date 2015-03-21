using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.ViewModels
{
    public class QuestionListViewModel
    {
        public string Beschrijving { get; private set; }
        public string Answer { get; private set; }
        public List<SelectListItem> OptAnswers { get; private set; }


        public QuestionListViewModel(ClimateChart c, Parameter p)
        {
            Beschrijving = p.Beschrijving;
            Answer = p.GiveAnswer(c);
            OptAnswers = p.GiveOptAnswers(c);
        }
    }
}