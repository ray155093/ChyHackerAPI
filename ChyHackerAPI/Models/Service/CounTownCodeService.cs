using ChyHackerAPI.Models.Data.CounTownCodeQery;
using ChyHackerAPI.Models.Data.Enum;
using ChyHackerAPI.Models.IService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using static ChyHackerAPI.Models.Service.CounTownCodeQery.CounTownCodeService;

namespace ChyHackerAPI.Models.Service
{
    public partial class CounTownCodeService : ICounTownCodeService
    {


        private SimpleDataTypeFactory _DataTypeFactory;
        private CounTownCodeInput _input;

        public CounTownCodeService(CounTownCodeInput input)
        {
            _input = input;
            _DataTypeFactory = new SimpleDataTypeFactory(input.DataType);
        }

        public object GetLists()
        {
            ICounTownCodeQueryProvide query = _DataTypeFactory.CreateQuery(_input);
            var result = query.GetLists();
            return result;
        }


        public object GetStatistics()
        {
            ICounTownCodeQueryProvide query = _DataTypeFactory.CreateQuery(_input);
            var result = query.GetStatistics();
            return result;
        }
        #region 共用

        /// <summary>
        /// 簡單工廠模式
        /// </summary>
        private class SimpleDataTypeFactory
        {
            private EDataType _dataType;

            public SimpleDataTypeFactory(EDataType dataType)
            {
                _dataType = dataType;
            }

            /// <summary>
            /// 依照輸入資料判斷要查詢哪種資料
            /// </summary>
            /// <returns></returns>
            public ICounTownCodeQueryProvide CreateQuery(CounTownCodeInput input)
            {
                string _conn = ConfigurationManager.ConnectionStrings["SQL"].ToString();
                ICounTownCodeQueryProvide query;
                switch (_dataType)
                {
                    case EDataType.民宿清單:
                        return query = new CounTownCodeQueryBab(input, _conn); 
                    case EDataType.旅館清單:
                        return query = new CounTownCodeQueryHotel(input,_conn);
                    case EDataType.景點:
                        return query = new CounTownCodeQueryPOI(input, _conn);
                    case EDataType.旅館人數:
                        return query = new CounTownCodeQueryHotelPeople(input, _conn);
                    case EDataType.民宿人數:
                        return query = new CounTownCodeQueryBabPeople(input, _conn);
                    case EDataType.區域旅客國籍:
                        return query = new CounTownCodeQueryPassengersNa(input, _conn);
                    case EDataType.poly:
                        return query = new CounTownCodeQueryPoly(input, _conn);
                    case EDataType.縣市網格:
                        return query = new CounTownCodeQueryCountNetInfo(input, _conn);
                    default:
                        return null;
                }
            }

        }

        #endregion

    }
}