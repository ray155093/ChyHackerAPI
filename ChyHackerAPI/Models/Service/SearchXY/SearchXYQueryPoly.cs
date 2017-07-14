using ChyHackerAPI.Models.Data.SearchXYQuery;
using ChyHackerAPI.Models.IService;
using RiChi.Library.ADO;
using System;
using System.Collections.Generic;

namespace ChyHackerAPI.Models.Service
{
    public partial class SearchXYService
    {
        /// <summary>
        /// POI
        /// </summary>
        /// <seealso cref="ChyHackerAPI.Models.IService.SearchXYService" />
        /// <seealso cref="ChyHackerAPI.Models.IService.ISearchXYQueryProvide" />
        public class SearchXYQueryPoly : SearchXYQuery, ISearchXYQueryProvide
        {
            private SearchXYInput _input;

            public SearchXYQueryPoly(SearchXYInput input, string _conn)
            {
                this._input = input;
                _ado = new MSSQL(_conn);
            }

            public SearchXYQueryPoly(string _conn)
            {
                _ado = new MSSQL(_conn);
            }

            public object GetLists()
            {
                var result = "";

                return result;
            }

            public object GetStatistics(string _X, string _Y, int _Buffer)
            {
                Dictionary<string, object> _params = new Dictionary<string, object>();
                _params.Add("@X", new MSParameters(_X, SQLType.NVarChar));
                _params.Add("@Y", new MSParameters(_Y, SQLType.NVarChar));
                _params.Add("@Dis", new MSParameters(_Buffer, SQLType.Int));
                var result = _ado.Procedure_Generic<Data.DB.UseXYPOI>("USP_Qry_UseXYLandMarkList", _params);

                return result;
            }

            public object GetStatistics(SearchXYInput input)
            {
                throw new NotImplementedException();
            }

            public object GetStatistics()
            {
                throw new NotImplementedException();
            }

            public object GetLists(SearchXYInput input)
            {
                Dictionary<string, object> _params = new Dictionary<string, object>();
                _params.Add("@X", new MSParameters(input.X, SQLType.NVarChar));
                _params.Add("@Y", new MSParameters(input.Y, SQLType.NVarChar));
                _params.Add("@Dis", new MSParameters(input.Buffer, SQLType.Int));
                var result = _ado.Procedure_Generic<Data.DB.UseXYPOI>("USP_Qry_UseXYLandMarkList", _params);

                return result;
            }
        }
    }
}