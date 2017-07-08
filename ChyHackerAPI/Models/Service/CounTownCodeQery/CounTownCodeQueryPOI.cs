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
        public class CounTownCodeQueryPOI : CounTownCodeQuery, ICounTownCodeQueryProvide
        {
            private CounTownCodeInput _input;

            public CounTownCodeQueryPOI(CounTownCodeInput input, string _conn)
            {
                this._input = input;
                _ado = new MSSQL(_conn);
            }

            public object GetLists()
            {
                var sqlStr = $@"SELECT TOP 1000 A.[COUN_NA] ,A.[TOWN_NA]
                                  ,[Name],[Class],[X] ,[Y]
                                  ,[ADD],[TEL],[Web]
                                  ,[Description],[Pic],[SHAPE_97].ToString()'Poly'
                              FROM [RiChiCHYHacker].[dbo].[POI] A
							  LEFT JOIN [dbo].[TOWNSHIP] B
							  ON A.TOWN_ID= B.TOWN_ID 
                              WHERE A.TOWN_ID =@TOWN_ID";

                Dictionary<string, object> _param = new Dictionary<string, object>();
                _param.Add("@TOWN_ID", new MSParameters(_input.Town_ID, SQLType.NVarChar));

                var result = _ado.Select<Data.DB.POI>(sqlStr, _param);
                return result;
            }

            public object GetStatistics()
            {
                throw new NotImplementedException();
            }
        }
    }
}