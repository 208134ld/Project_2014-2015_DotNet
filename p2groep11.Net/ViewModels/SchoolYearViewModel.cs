using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep11.Net.Models;

namespace p2groep11.Net.ViewModels
{

    public class SchoolYearCreateViewModel
    {
        public SelectList Schoolyear { get; set; }
        public SchoolYearViewModel schoolyearNumber { get; set; }

        public SchoolYearCreateViewModel(IEnumerable<SchoolYear> years, SchoolYearViewModel school)
        {
            Schoolyear = new SelectList(years,"number","number");
            schoolyearNumber = school;
        }

    }

    public class SchoolYearViewModel
    {
        public int number { get; set; }

        public SchoolYearViewModel()
        {
            
        }
    }

}