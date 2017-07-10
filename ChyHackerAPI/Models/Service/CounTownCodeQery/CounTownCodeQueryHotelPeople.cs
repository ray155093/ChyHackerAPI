using ChyHackerAPI.Models.IService;
using RiChi.Library.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChyHackerAPI.Models.Data.CounTownCodeQery;

namespace ChyHackerAPI.Models.Service.CounTownCodeQery
{

    public partial class CounTownCodeService
    {
        /// <summary>
        /// POI
        /// </summary>
        /// <seealso cref="ChyHackerAPI.Models.IService.CounTownCodeQuery" />
        /// <seealso cref="ChyHackerAPI.Models.IService.ICounTownCodeQueryProvide" />
        public class CounTownCodeQueryHotelPeople : CounTownCodeQuery, ICounTownCodeQueryProvide
        {
            private CounTownCodeInput _input;

            public CounTownCodeQueryHotelPeople(CounTownCodeInput input, string _conn)
            {
                this._input = input;
                _ado = new MSSQL(_conn);
            }

            public object GetLists()
            {
                throw new NotImplementedException();

            }

            public object GetStatistics()
            {
                var sqlStr = $@"SELECT 
                                TOWN_ID, TOWN_NA, YEAR, MONTH, TYPE,SUM( VALUE) VALUE 
                                FROM Hotel
                                WHERE TOWN_ID=TOWN_ID AND [YEAR]=@YEAR AND [MONTH]=@MONTH
                                GROUP BY TOWN_ID, TOWN_NA, YEAR, MONTH, TYPE
                                ORDER BY TOWN_ID, TOWN_NA, YEAR, MONTH, TYPE";

                Dictionary<string, object> _param = new Dictionary<string, object>();
                _param.Add("@TOWN_ID", new MSParameters(_input.Town_ID, SQLType.NVarChar));
                _param.Add("@YEAR", new MSParameters(_input.QueryYear, SQLType.NVarChar));
                _param.Add("@MONTH", new MSParameters(_input.QueryMonth, SQLType.NVarChar));

                var result = _ado.Select<Data.DB.HotelInfo>(sqlStr, _param);
                return result;
            }
        }
    }
}