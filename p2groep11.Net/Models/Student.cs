using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep11.Net.Models
{
    public class Student
    {

        
       
        private String lastname;
        private String firstname;
        private String username;
        private String password;
         public String Lastname
        {
            get { return lastname;}
            set
            {
                if (value.Length > 1)
                    this.lastname = value;
                else throw new ArgumentException("Lastname can't be empty.");
            }
        }

        public Grade Grade { get; set; }

        public String Firstname
        {
            get { return firstname; }
            set
            {
                if (value.Length > 1)
                    this.firstname = value;
                else throw new ArgumentException("Firstname can't be empty.");
            }
        }
        public Student(String fname,String lname)
        {
            Firstname = fname;
            Lastname = lname;
        }

        public Student()
        {
            
        }
        public Boolean isSecondGrader()
        {
            return Grade.Number == 2;
        }

    }
}
