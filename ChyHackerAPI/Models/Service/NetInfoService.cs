using ChyHackerAPI.Models.Data.DB;
using RiChi.Library.ADO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ChyHackerAPI.Models.Service
{
    public class NetInfoService
    {
        public static string _conn = ConfigurationManager.ConnectionStrings["SQL"].ToString();
        private MSSQL _ado = new MSSQL(_conn);

        public NetInfoService()
        {

        }
        public object GetLists(string polyStr)
        {
            DataTable dt = new DataTable();
            Dictionary<string, object> sqlParams = new Dictionary<string, object>();
            string sp_name = "USP_QRY_NET_INFO";
            sqlParams.Add("POLY_STR", new MSParameters(polyStr, SQLType.NVarChar));
            var olists = _ado.Procedure_Generic<NetInfo>(sp_name, sqlParams);
            return olists;

        }
    }
}