using ChyHackerAPI.Models.Data.SummaryVillQuery;
using ChyHackerAPI.Models.IService;
using RiChi.Library.ADO;
using System;
using System.Collections.Generic;

namespace ChyHackerAPI.Models.Service
{
    public partial class SummaryVillService
    {
        /// <summary>
        /// POI
        /// </summary>
        /// <seealso cref="ChyHackerAPI.Models.IService.SummaryVillQuery" />
        /// <seealso cref="ChyHackerAPI.Models.IService.ISummaryVillQueryProvide" />
        public class SummaryVillQueryPoly : SummaryVillQuery, ISummaryVillQueryProvide
        {
            private SummaryVillInput _input;

            public SummaryVillQueryPoly(SummaryVillInput input, string _conn)
            {
                this._input = input;
                _ado = new MSSQL(_conn);
            }

            public SummaryVillQueryPoly(string _conn)
            {
                _ado = new MSSQL(_conn);
            }

            public object GetLists()
            {
                var sqlStr = $@"SELECT OBJECTID,COUN_ID,COUN_NA,TOWN_ID,TOWN_NA,VLG_ID,VLG_NA
                                ,centroid_X,centroid_Y,Shape.ToString() ShapePOLY
                                ,Replace (Replace (Replace (Shape.ToString(), 'POLYGON','' ), '((','' ), '))','' ) POLY
                                ,IsShow
                                FROM VillageNode ORDER BY 1";

                Dictionary<string, object> _param = new Dictionary<string, object>();

                var result = _ado.Select<Data.DB.Village>(sqlStr, _param);
                return result;
            }

            public object GetStatistics(string _vill_id)
            {
                var sqlStr = "SELECT top 1 * FROM SUMMARY_Village where VLG_ID = '" + _vill_id + "'";
                var result = _ado.Select<Data.DB.SummaryVill>(sqlStr);
                return result;
            }

            public object GetStatistics()
            {
                throw new NotImplementedException();
            }
        }
    }
}