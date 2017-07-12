using ChyHackerAPI.Models.Data.CounTownCodeQery;
using ChyHackerAPI.Models.Data.DB;
using ChyHackerAPI.Models.Data.Enum;
using ChyHackerAPI.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChyHackerAPI.Controllers
{
    public class CounTownCodeController : BaseController
    {
        private CounTownCodeInput _input;
        /// <summary>
        /// 清單
        /// </summary>
        /// <param name="town_id">The town identifier.</param>
        /// <param name="type">The type.</param>
        public void Get(string town_id, string type)
        {
            _input = new CounTownCodeInput
            {
                Town_ID = town_id,
                DataType = GetDataType(type),
                QueryLevel = Models.Data.Enum.EQueryLevel.Town
            };
            var service = new CounTownCodeService(_input);

            var result = service.GetLists();
            base.JsonResponse(result);
        }

        public void Get(string town_id, int year, int month, string type)
        {
            _input = new CounTownCodeInput
            {
                Town_ID = town_id,
                DataType = GetDataType(type),
                QueryYear = year,
                QueryMonth = month
            };
            var service = new CounTownCodeService(_input);

            var result = service.GetStatistics();
            base.JsonResponse(result);
        }
        public void Get(string type)
        {
            _input = new CounTownCodeInput
            {
                DataType = GetDataType(type),
                QueryLevel = Models.Data.Enum.EQueryLevel.Count
            };
            var service = new CounTownCodeService(_input);

            var result = service.GetLists();
            switch (_input.DataType)
            {
                case EDataType.縣市網格:
                    base.JsonResponse<List<NetInfo>>((List<NetInfo>)result);
                    break;
                case EDataType.景點:
                    base.JsonResponse<List<POI>>((List<POI>)result);
                    break;
                case EDataType.縣市公車站:
                    base.JsonResponse<List<BUSSTOPS>>((List<BUSSTOPS>)result);
                    break;
                default:
                    base.JsonResponse(result);
                    break;
            }
        }
       
    }

}
