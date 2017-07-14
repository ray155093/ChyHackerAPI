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
        public class CounTownCodeQueryTownSupplyDemand : CounTownCodeQuery, ICounTownCodeQueryProvide
        {
            private CounTownCodeInput _input;

            public CounTownCodeQueryTownSupplyDemand(CounTownCodeInput input, string _conn)
            {
                this._input = input;
                _ado = new MSSQL(_conn);
            }

            public object GetLists()
            {
                var sqlStr = $@"
                               SELECT TOP 1000 
                                      [MONTH]
                                      ,[STAY_TOTAL]'SUPPLY'
	                                  ,CONVERT(INT,[STAY_TOTAL]*[STAY_RATE])'DEMAND'
                                  FROM [RiChiCHYHacker].[dbo].[PEOPLE_STAY]
                                  WHERE TOWN_ID=@TOWN_ID AND TYPE=@TYPE
                                  ORDER BY [TOWN_ID] ,MONTH
                                ";

                Dictionary<string, object> _param = new Dictionary<string, object>();
                _param.Add("@Town_ID", new MSParameters(_input.Town_ID, SQLType.NVarChar));
                _param.Add("@TYPE", new MSParameters(_input.ServiceImplementType, SQLType.NVarChar));

                var result = _ado.Select<Data.DB.SupplyDemand>(sqlStr, _param);
                return result;
            }


            public object GetStatistics()
            {
                throw new NotImplementedException();
            }
        }
    }
}