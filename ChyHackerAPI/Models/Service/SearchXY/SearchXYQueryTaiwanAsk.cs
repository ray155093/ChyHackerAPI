using ChyHackerAPI.Models.Data.SearchXYQuery;
using ChyHackerAPI.Models.IService;
using RiChi.Library.ADO;

namespace ChyHackerAPI.Models.Service
{
    public class SearchXYQueryTaiwanAsk : SearchXYQuery, ISearchXYQueryProvide

    {
        public SearchXYQueryTaiwanAsk(string _conn)
        {
            _ado = new MSSQL(_conn);
        }

        public object GetLists(SearchXYInput input)
        {
            var sqlStr = "SELECT * FROM TaiwanAsk ";
            var result = _ado.Select<Data.DB.TaiwanAsk>(sqlStr);

            return result;
        }
    }
}