using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace p2groep11.Net.Models.Domain
{
    public class Grade
    {
        private int grade;

        public int GradeId
        {
            get { return grade; }
            set
            {
                if (value > 0 && value <= 3)
                {
                    this.grade = value;
                }
                else throw new ArgumentException("Grade needs to be between 1 and 3.");
            }
        }
        public virtual DeterminateTable DeterminateTableProp { get; set; }
        public virtual ICollection<Continent> Continents { get; set; }
        public virtual ICollection<SchoolYear> SchoolYears { get; private set; }

        public Grade()
        {
            SchoolYears = new List<SchoolYear>();
            Continents = new List<Continent>();
        }

        public Grade(int selectedYear)
        {
            CalculateGrade(selectedYear);
            SchoolYears = new List<SchoolYear>();
            Continents = new List<Continent>();
            GradeId = grade;
        }

        public void CalculateGrade(int selectedYear)
        {
            grade = (selectedYear + 1)/2;
        }

    }
}
