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
        public int GradeInt
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
        public virtual DeterminateTable DeterminateTableProp{ get; set; }
        public virtual ICollection<Continent> ContinentProp { get; set; }
        public virtual ICollection<SchoolYear> SchoolYearProp { get; set; } //nog niet zeker of we dit gaan nodig hebben

        public Grade()
        {
            
        }

        public Grade(SchoolYear schoolYear)
        {
            GradeInt = CalculateGrade(schoolYear.Year);
        }

        public int CalculateGrade(int year )
        {
            return (year + 1) / 2;
        }

    }
}
