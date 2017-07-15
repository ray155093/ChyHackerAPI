using ChyHackerAPI.Models.Data.SearchXYQuery;
using ChyHackerAPI.Models.IService;
using RiChi.Library.ADO;
using System.Collections.Generic;

namespace ChyHackerAPI.Models.Service
{
    public partial class SearchXYService
    {
        private class SearchXYQueryFactory : SearchXYQuery, ISearchXYQueryProvide
        {
            public SearchXYQueryFactory(string _conn)
            {
                _ado = new MSSQL(_conn);
            }

            public object GetLists(SearchXYInput input)
            {
                Dictionary<string, object> _params = new Dictionary<string, object>();
                _params.Add("@X", new MSParameters(input.X, SQLType.NVarChar));
                _params.Add("@Y", new MSParameters(input.Y, SQLType.NVarChar));
                _params.Add("@Dis", new MSParameters(input.Buffer, SQLType.Int));

                var result = _ado.Procedure_Generic<Data.DB.UseXYFACTORY>("USP_QryFACTORY_UseXY", _params);
                return result;
            }
        }
    }
}