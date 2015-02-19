﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace p2groep11.Net.Models.Domain
{
    public class SchoolYear
    {

        private double year;
        public double Year
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
        public int CalculateGrade()
        {
    return (int) Math.Ceiling(year/2);
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
