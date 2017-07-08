using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChyHackerAPI.Models.Data.DB
{
    public class PassengersNa : Town
    {
        public string YEAR { get; set; }
        public string MONTH { get; set; }
        public string NATIONALITY { get; set; }
        public int VALUE { get; set; }

    }
}