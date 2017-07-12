using RiChi.Library.ADO;

namespace ChyHackerAPI.Models.IService
{
    public interface ISummaryVillService
    {
        object GetLists();

        object GetStatistics();
    }

    public abstract class SummaryVillQuery
    {
        public MSSQL _ado { get; set; }
    }

    public interface ISummaryVillQueryProvide
    {
        object GetStatistics();

        object GetLists();
    }
}