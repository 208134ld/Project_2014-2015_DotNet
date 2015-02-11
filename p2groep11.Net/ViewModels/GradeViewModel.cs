using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep11.Net.Models;

namespace p2groep11.Net.ViewModels
{
    public class GradeViewModel
    {
        //public SelectList Grades { get; private set; }
        //public SelectList SchoolYears { get; private set; }
        [Required]
        [Display(Name = "Graad")]
        public int Grades { get; private set; }
        [Required]
        [Display(Name = "Schooljaar")]
        public Form SchoolYears { get; private set; }

        public GradeViewModel(Grade graad)
        {
            Grades = graad.Number;
            SchoolYears = graad.Form;
        }
    }
}