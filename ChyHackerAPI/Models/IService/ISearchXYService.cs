using ChyHackerAPI.Models.Data.SearchXYQuery;
using RiChi.Library.ADO;

namespace ChyHackerAPI.Models.IService
{
    public interface ISearchXYService
    {
        object GetLists(SearchXYInput input);
    }

    public abstract class SearchXYQuery
    {
        public MSSQL _ado { get; set; }
    }

    public interface ISearchXYQueryProvide
    {
        object GetLists(SearchXYInput input);
    }
}