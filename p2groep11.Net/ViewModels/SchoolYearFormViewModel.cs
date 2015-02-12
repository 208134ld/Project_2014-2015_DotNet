using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep11.Net.Models;

namespace p2groep11.Net.ViewModels
{

    public class SchoolYearFormViewModel
    {
        public List<SelectListItem> SchoolYears { set; get; }

        [Required]
        [Display(Name = "Schooljaar")]
        public int SelectedYear { get; set; }
    

        public SchoolYearFormViewModel(List<SelectListItem> SYears )
        {
            SchoolYears = SYears;

        }

        public SchoolYearFormViewModel()
        {
            
        }

    }



}