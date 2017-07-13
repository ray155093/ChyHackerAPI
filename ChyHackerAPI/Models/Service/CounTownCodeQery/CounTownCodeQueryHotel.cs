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
        public class CounTownCodeQueryHotel : CounTownCodeQuery, ICounTownCodeQueryProvide
        {
            private CounTownCodeInput _input;

            public CounTownCodeQueryHotel(CounTownCodeInput input, string _conn)
            {
                this._input = input;
                _ado = new MSSQL(_conn);
            }

            public object GetLists()
            {
                var sqlStr = $@"
                                SELECT
                                HOTEL_NAME NAME, BOSS, TEL, FAX, ADDRESS, ROOM_NUM
                                , ROOM_PRICE, AREA,AVG_ROOM_PRICE, CUSTOMER, STUFF, X, Y
                                FROM HOTEL_LIST
                                WHERE TOWN_ID =@TOWN_ID
                                ";

                Dictionary<string, object> _param = new Dictionary<string, object>();
                _param.Add("@Town_ID", new MSParameters(_input.Town_ID, SQLType.NVarChar));

                var result = _ado.Select<Data.DB.Hotel>(sqlStr, _param);
                return result;
            }


            public object GetStatistics()
            {
                throw new NotImplementedException();
            }
        }
    }
}