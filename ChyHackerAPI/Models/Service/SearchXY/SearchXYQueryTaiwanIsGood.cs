using ChyHackerAPI.Models.Data.SearchXYQuery;
using ChyHackerAPI.Models.IService;
using RiChi.Library.ADO;

namespace ChyHackerAPI.Models.Service
{
    public class SearchXYQueryTaiwanIsGood : SearchXYQuery, ISearchXYQueryProvide

    {
        public SearchXYQueryTaiwanIsGood(string _conn)
        {
            _ado = new MSSQL(_conn);
        }

        public object GetLists(SearchXYInput input)
        {
            var sqlStr = "SELECT * FROM TaiwanIsGood ";
            var result = _ado.Select<Data.DB.TaiwanIsGood>(sqlStr);

            return result;
        }
    }
}