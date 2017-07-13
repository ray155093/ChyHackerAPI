using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChyHackerAPI.Models.Data.DB
{
    public class NetInfo
    {
        public string PAGENAME { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string COUNT_POI { get; set; }
        public string NEAR_DIST { get; set; }
        public string STOPNAME { get; set; }
        public string IS_BUS { get; set; }
        public string XY { get; set; }
        public string COLOR_COUNT_POI { get; set; }
        public string COLOR_NEAR_DIST { get; set; }
        public string [][] coordinates { get; set; }


    }
}