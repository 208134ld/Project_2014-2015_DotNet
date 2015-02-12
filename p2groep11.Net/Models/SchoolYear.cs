using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace p2groep11.Net.Models
{
    public class SchoolYear
    {

        private int number;

        public int Number
        {
            get { return number; }
            set
            {
                if (value > 0 && value <= 6)
                {
                    this.number = value;
                }
                else throw new ArgumentException("Number needs to be between 1 and 6.");
            }
        }



    }
}
