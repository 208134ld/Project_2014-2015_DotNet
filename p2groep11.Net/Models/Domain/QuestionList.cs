using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2groep11.Net.Models.Domain
{
    public class QuestionList
    {
        public int QuestionListID { get; set; }
        public virtual ICollection<Parameter> Parameters { get; set; }

        public QuestionList()
        {
            Parameters = new List<Parameter>();
        }
    }
}