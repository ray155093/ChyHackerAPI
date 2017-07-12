using ChyHackerAPI.Models.Data.SummaryVillQuery;
using ChyHackerAPI.Models.Service;

namespace ChyHackerAPI.Controllers
{
    public class SummaryVillController : BaseController
    {
        /// <summary>
        /// Gets the specified town identifier.
        /// </summary>

        public void Get()

        {
            var service = new SummaryVillService();

            var result = service.GetLists();
            base.JsonResponse(result);
        }

        /// <summary>
        /// 清單
        /// </summary>
        /// <param name="town_id">The town identifier.</param>
        /// <param name="type">The type.</param>
        public void Get(string town_id, string type)
        {
            var input = new SummaryVillInput
            {
                Town_ID = town_id,
                DataType = GetDataType(type)
            };
            var service = new SummaryVillService(input);

            var result = service.GetLists();
            base.JsonResponse(result);
        }

        public void Get(string town_id, int year, int month, string type)
        {
            var input = new SummaryVillInput
            {
                Town_ID = town_id,
                DataType = GetDataType(type),
                QueryYear = year,
                QueryMonth = month
            };
            var service = new SummaryVillService(input);

            var result = service.GetStatistics();
            base.JsonResponse(result);
        }
    }
}