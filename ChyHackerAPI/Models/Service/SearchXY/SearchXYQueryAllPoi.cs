using ChyHackerAPI.Models.Data.SearchXYQuery;
using ChyHackerAPI.Models.IService;
using RiChi.Library.ADO;
using System.Collections.Generic;

namespace ChyHackerAPI.Models.Service
{
    public partial class SearchXYService
    {
        private class SearchXYQueryAllPoi: SearchXYQuery, ISearchXYQueryProvide
        {
            public SearchXYQueryAllPoi(string _conn)
            {
                _ado = new MSSQL(_conn);
            }

            public object GetLists(SearchXYInput input)
            {
                var sqlStr = "SELECT * FROM POI ";
                var result = _ado.Select<Data.DB.UseXYPOI>(sqlStr);

                return result;
            }
        }
    }
}