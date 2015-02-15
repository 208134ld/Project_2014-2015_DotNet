using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace p2groep11.Net.Models.Domain
{
    public class SchoolYear
    {

        private int year;
        private int grade;

        public int Year
        {
            get { return year; }
            set
            {
                if (value > 0 && value <= 6)
                {
                    this.year = value;
                }
                else throw new ArgumentException("Year needs to be between 1 and 6.");
            }
        }

        public int Grade
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

        public int CalculateGrade()
        {
            switch (year)
            {
                case 1:
                case 2:
                    return Grade = 1;
                case 3:
                case 4:
                    return Grade = 2;
                default:
                    return Grade = 3;
            }
        }

        public SchoolYear()
        {
            
        }

        public SchoolYear(int number)
        {
            this.year = number;
        }


    }
}
