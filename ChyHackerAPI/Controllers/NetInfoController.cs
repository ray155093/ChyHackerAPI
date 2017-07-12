using ChyHackerAPI.Models.Data.DB;
using ChyHackerAPI.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChyHackerAPI.Controllers
{
    public class NetInfoController : BaseController
    {
        [HttpPost]
        public void post(NetRequest oRequest)
        {
            string polystr = "POLYGON ((";
            for (int i = 0; i < oRequest.Geometry.Length; i++)
            {
                polystr += oRequest.Geometry[i][0] + " " + oRequest.Geometry[i][1] + ",";
            }
            polystr = polystr.TrimEnd(',');
            polystr += "))";
            var service = new NetInfoService();
            var result = service.GetLists(polystr);
            base.JsonResponse<List<NetInfo>>((List<NetInfo>)result);
        }
    }
}
