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
        public class CounTownCodeQueryPassengersNa : CounTownCodeQuery, ICounTownCodeQueryProvide
        {
            private CounTownCodeInput _input;

            public CounTownCodeQueryPassengersNa(CounTownCodeInput input, string _conn)
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
                var sqlStr = $@"SELECT TOP 1000 TOWN_NA, YEAR, MONTH, NATIONALITY, VALUE
                                  FROM [RiChiCHYHacker].[dbo].[Hotel_Contry] A
                                  WHERE TOWN_ID =TOWN_ID AND [YEAR]=@YEAR AND [MONTH]=@MONTH
                                  ORDER BY TOWN_ID
                                ";

                Dictionary<string, object> _param = new Dictionary<string, object>();
                _param.Add("@TOWN_ID", new MSParameters(_input.Town_ID, SQLType.NVarChar));
                _param.Add("@YEAR", new MSParameters(_input.QueryYear, SQLType.NVarChar));
                _param.Add("@MONTH", new MSParameters(_input.QueryMonth, SQLType.NVarChar));

                var result = _ado.Select<Data.DB.PassengersNa>(sqlStr, _param);
                return result;
            }
        }
    }
}