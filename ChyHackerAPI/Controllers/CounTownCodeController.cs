using ChyHackerAPI.Models.Data.CounTownCodeQery;
using ChyHackerAPI.Models.Service;

namespace ChyHackerAPI.Controllers
{
    public class CounTownCodeController : BaseController
    {
        /// <summary>
        /// 清單
        /// </summary>
        /// <param name="vill_id">The town identifier.</param>
        /// <param name="type">The type.</param>
        public void Get(string town_id, string type)
        {
            var input = new CounTownCodeInput
            {
                Town_ID = town_id,
                DataType = GetDataType(type)
            };
            var service = new CounTownCodeService(input);

            var result = service.GetLists();
            base.JsonResponse(result);
        }

        public void Get(string town_id, int year, int month, string type)
        {
            var input = new CounTownCodeInput
            {
                Town_ID = town_id,
                DataType = GetDataType(type),
                QueryYear = year,
                QueryMonth = month
            };
            var service = new CounTownCodeService(input);

            var result = service.GetStatistics();
            base.JsonResponse(result);
        }
    }
}