using RiChi.Library.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChyHackerAPI.Models.IService
{
    public interface ICounTownCodeService
    {
        object GetLists();
        object GetStatistics();
    }
    public abstract class CounTownCodeQuery
    {
        public MSSQL _ado { get; set; }
    }
    public interface ICounTownCodeQueryProvide
    {
        object GetStatistics();
        object GetLists();
    }
}