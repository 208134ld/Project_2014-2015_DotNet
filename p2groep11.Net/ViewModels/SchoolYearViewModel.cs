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
        public List<SelectListItem> SchoolYears { set; get; }
        public int SelectedYear { get; set; }
    

        public SchoolYearCreateViewModel(List<SelectListItem> SYears )
        {
            SchoolYears = SYears;

        }

        public SchoolYearCreateViewModel()
        {
            
        }

    }



}