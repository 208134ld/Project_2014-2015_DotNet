using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep11.Net.Models.Domain
{
    public class Month
    {
        public int Id { get; set; }
        //Gemiddelde Temperatuur
        public int AverTemp { get; set; }
        public int Sediment { get; set; }

        public Month(int month, int temp, int sed)
        {
            Id = month;
            AverTemp = temp;
            Sediment = sed;
        }
    }
}
