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
        public class CounTownCodeQueryBusStation : CounTownCodeQuery, ICounTownCodeQueryProvide
        {
            private CounTownCodeInput _input;

            public CounTownCodeQueryBusStation(CounTownCodeInput input, string _conn)
            {
                this._input = input;
                _ado = new MSSQL(_conn);
            }

            public object GetLists()
            {
                var sqlStr = $@"
                                SELECT TOP 1000 [OBJECTID]
                                  ,[StopName]+'('+[StopNameEn]+')'[StopName]
                                  ,[StopAddres]
                                  ,[Lon]
                                  ,[Lat]
                                  ,CONVERT (INT,[X_97])X
                                  ,CONVERT (INT,[Y_97])Y
                              FROM [RiChiCHYHacker].[dbo].[BUSSTOPS]
                                ";

                var result = _ado.Select<Data.DB.BUSSTOPS>(sqlStr, null);
                return result;
            }


            public object GetStatistics()
            {
                throw new NotImplementedException();
            }
        }
    }
}