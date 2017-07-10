using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChyHackerAPI.Models.Data.DB
{
    public class HotelInfo : Town
    {
        public string YEAR { get; set; }
        public string MONTH { get; set; }
        public string TYPE { get; set; }
        public string VALUE { get; set; }
    }
}