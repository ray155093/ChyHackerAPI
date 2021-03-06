﻿using RiChi.Library.ADO;

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