using ChyHackerAPI.Models.Data.Enum;
using ChyHackerAPI.Models.Data.SummaryVillQuery;
using ChyHackerAPI.Models.IService;
using System.Configuration;

namespace ChyHackerAPI.Models.Service
{
    public partial class SummaryVillService : ISummaryVillService
    {
        private SimpleDataTypeFactory _DataTypeFactory;
        private SummaryVillInput _input;

        public SummaryVillService()
        {
            _DataTypeFactory = new SimpleDataTypeFactory();
        }

        public SummaryVillService(SummaryVillInput input)
        {
            _input = input;
            _DataTypeFactory = new SimpleDataTypeFactory(input.DataType);
        }

        public object GetLists()
        {
            ISummaryVillQueryProvide query = _DataTypeFactory.CreateQuery(_input);
            var result = query.GetLists();
            return result;
        }

        public object GetStatistics(string _vill_id)
        {
            ISummaryVillQueryProvide query = _DataTypeFactory.CreateQuery(_input);
            var result = query.GetStatistics(_vill_id);
            return result;
        }

        public object GetStatistics()
        {
            ISummaryVillQueryProvide query = _DataTypeFactory.CreateQuery(_input);
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

            public SimpleDataTypeFactory()
            {
            }

            /// <summary>
            /// 依照輸入資料判斷要查詢哪種資料
            /// </summary>
            /// <returns></returns>
            public ISummaryVillQueryProvide CreateQuery(SummaryVillInput input)
            {
                string _conn = ConfigurationManager.ConnectionStrings["SQL"].ToString();
                ISummaryVillQueryProvide query;
                switch (_dataType)
                {
                    case EDataType.poly:
                        return query = new SummaryVillQueryPoly(_conn);

                    default:
                        //return null;
                        return query = new SummaryVillQueryPoly(_conn);
                }
            }
        }

        #endregion 共用
    }
}