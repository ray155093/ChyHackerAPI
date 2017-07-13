using ChyHackerAPI.Models.IService;
using RiChi.Library.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChyHackerAPI.Models.Data.CounTownCodeQery;
using ChyHackerAPI.Models.Data.Enum;
using System.ComponentModel;
using System.Dynamic;

namespace ChyHackerAPI.Models.Service.CounTownCodeQery
{

    public partial class CounTownCodeService
    {
        /// <summary>
        /// POI
        /// </summary>
        /// <seealso cref="ChyHackerAPI.Models.IService.CounTownCodeQuery" />
        /// <seealso cref="ChyHackerAPI.Models.IService.ICounTownCodeQueryProvide" />
        public class CounTownCodeQueryPOI : CounTownCodeQuery, ICounTownCodeQueryProvide
        {
            private CounTownCodeInput _input;

            public CounTownCodeQueryPOI(CounTownCodeInput input, string _conn)
            {
                this._input = input;
                _ado = new MSSQL(_conn);
            }

            public object GetLists()
            {
                dynamic result;
                var sqlStr = "";
                switch (_input.QueryLevel)
                {
                    case EQueryLevel.Count:
                        sqlStr = $@"SELECT TOP 1000 A.[COUN_NA] ,A.[TOWN_NA]
                                  ,[Name],[Class],[X] ,[Y]
                                  ,[ADD],[TEL],[Web]
                                  ,[Description],[Pic]
                                  ,[IS_Sidewalk]
                                  ,[IS_BusStop]
                                  ,CONVERT(INT,[NotQualify_Length])NotQualify_Length
                                  ,CONVERT(INT,[Qualify_Length])Qualify_Length
                                  ,[SHAPE_97].ToString()'Poly'
                              FROM [RiChiCHYHacker].[dbo].[POI] A
							  LEFT JOIN [dbo].[TOWNSHIP] B
							  ON A.TOWN_ID= B.TOWN_ID 
                            ";
                        result = _ado.Select<Data.DB.POI>(sqlStr, null);
                        //這樣轉過但是資料太多時會因為controller的tojsonGG
                        /*
                         * 
                       
                        */
                        var dynamicResult = (IDictionary<string, object>)ToDynamic(result);
                        dynamicResult.Remove("TOWN_ID");
                        dynamicResult.Remove("TOWN_NA");
                        dynamicResult.Remove("POLY");
                        return dynamicResult;

                        break;
                    case EQueryLevel.Town:
                        sqlStr = $@"SELECT TOP 1000 A.[COUN_NA] ,A.[TOWN_NA]
                                  ,[Name],[Class],[X] ,[Y]
                                  ,[ADD],[TEL],[Web]
                                  ,[Description],[Pic] ,[IS_Sidewalk]
                                  ,[IS_BusStop]
                                  ,CONVERT(INT,[NotQualify_Length])NotQualify_Length
                                  ,CONVERT(INT,[Qualify_Length])Qualify_Length
                                  ,[SHAPE_97].ToString()'Poly'
                              FROM [RiChiCHYHacker].[dbo].[POI] A
							  LEFT JOIN [dbo].[TOWNSHIP] B
							  ON A.TOWN_ID= B.TOWN_ID 
                              WHERE A.TOWN_ID =@TOWN_ID";

                        Dictionary<string, object> _param = new Dictionary<string, object>();
                        _param.Add("@TOWN_ID", new MSParameters(_input.Town_ID, SQLType.NVarChar));
                        result = _ado.Select<Data.DB.POI>(sqlStr, _param);
                        return result;
                        break;
                    default:
                        throw new NotImplementedException();
                }


            }

            public object GetStatistics()
            {
                throw new NotImplementedException();
            }
            public dynamic ToDynamic(object obj)
            {
                IDictionary<string, object> result = new ExpandoObject();

                foreach (PropertyDescriptor pro in TypeDescriptor.GetProperties(obj.GetType()))
                {
                    result.Add(pro.Name, pro.GetValue(obj));
                }

                return result as ExpandoObject;
            }
        }
    }
}