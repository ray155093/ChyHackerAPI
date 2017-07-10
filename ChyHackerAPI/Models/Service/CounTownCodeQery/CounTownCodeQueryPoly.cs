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
        public class CounTownCodeQueryPoly : CounTownCodeQuery, ICounTownCodeQueryProvide
        {
            private CounTownCodeInput _input;

            public CounTownCodeQueryPoly(CounTownCodeInput input, string _conn)
            {
                this._input = input;
                _ado = new MSSQL(_conn);
            }

            public object GetLists()
            {
                var sqlStr = $@"SELECT TOWN_ID,TOWN_NA,SHAPE_97.ToString() POLY FROM TOWNSHIP
                            ORDER BY 1";

                Dictionary<string, object> _param = new Dictionary<string, object>();
                
                var result = _ado.Select<Data.DB.Town>(sqlStr, _param);
                return result;
            }

            public object GetStatistics()
            {
                throw new NotImplementedException();
            }
        }
    }
}