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
        public class CounTownCodeQueryCountNetInfo : CounTownCodeQuery, ICounTownCodeQueryProvide
        {
            private CounTownCodeInput _input;

            public CounTownCodeQueryCountNetInfo(CounTownCodeInput input, string _conn)
            {
                this._input = input;
                _ado = new MSSQL(_conn);
            }

            public object GetLists()
            {
                var sqlStr = $@"
                                SELECT 
                                  [PageName] [PAGENAME]
                                  , CONVERT(int,[X])[X]
                                  , CONVERT(int,[Y])[Y]
                                 -- ,[BUFF_DIST]
                                  ,[Count_POI] [COUNT_POI]
                                  , CONVERT(int,[NEAR_DIST])[NEAR_DIST]
                                  ,[StopName]+'('+[StopNameEn]+')' [STOPNAME]-- 最靠近的公車站名稱
                                  ,[IS_BUS]--網格中心內500內有沒有公車站
                                  ,[Shape].ToString() XY
                              FROM [RiChiCHYHacker].[dbo].[BUSGRID]
                              --6605
                                ";
                var result = _ado.Select<Data.DB.NetInfo>(sqlStr, null);
                return result;
            }


            public object GetStatistics()
            {
                throw new NotImplementedException();
            }
        }
    }
}