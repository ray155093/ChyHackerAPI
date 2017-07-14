using ChyHackerAPI.Models.Data.Enum;
using ChyHackerAPI.Models.Data.SearchXYQuery;
using ChyHackerAPI.Models.IService;
using System.Configuration;

namespace ChyHackerAPI.Models.Service
{
    public partial class SearchXYService : ISearchXYService

    {
        private SimpleDataTypeFactory _DataTypeFactory;
        private SearchXYInput _input;

        public SearchXYService()
        {
            _DataTypeFactory = new SimpleDataTypeFactory();
        }

        public SearchXYService(SearchXYInput input)
        {
            //ISummaryVillQueryProvide query = _DataTypeFactory.CreateQuery(_input);

            _input = input;
            _DataTypeFactory = new SimpleDataTypeFactory(input.DataType);
        }

        public object GetLists(SearchXYInput input)
        {
            ISearchXYQueryProvide query = _DataTypeFactory.CreateQuery(_input);
            var result = query.GetLists(_input);
            return result;
        }

        private class SimpleDataTypeFactory
        {
            private EDataPOIType _dataType;

            public SimpleDataTypeFactory(EDataPOIType dataType)
            {
                _dataType = dataType;
            }

            public SimpleDataTypeFactory()
            {
            }

            public ISearchXYQueryProvide CreateQuery(SearchXYInput input)
            {
                string _conn = ConfigurationManager.ConnectionStrings["SQL"].ToString();
                ISearchXYQueryProvide query;
                switch (_dataType)
                {
                    case EDataPOIType.poly:
                        return query = new SearchXYQueryPoly(_conn);

                    default:
                        //return null;
                        return query = new SearchXYQueryPoly(_conn);
                }
            }
        }
    }
}