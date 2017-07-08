using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChyHackerAPI.Models.Data.DB
{
    public class  POI: Town
    {
        public string COUN_NA { set; get; }
        public string Name { set; get; }
        public string Class { set; get; }
        public string X { set; get; }
        public string Y { set; get; }
        public string ADD { set; get; }
        public string TEL { set; get; }
        public string Web { set; get; }
        public string Description { set; get; }
        public string Pic { set; get; }
    }
}