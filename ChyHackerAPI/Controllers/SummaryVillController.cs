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
        public void Get(string vill_id)
        {
            var input = new SummaryVillInput
            {
                Vill_ID = vill_id,
            };
            var service = new SummaryVillService(input);
            var result = service.GetStatistics(vill_id);
            base.JsonResponse(result);
        }

        //public void Get(string town_id, int year, int month, string type)
        //{
        //    base.JsonResponse(result);
        //}
    }
}