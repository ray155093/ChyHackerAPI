using ChyHackerAPI.Models.Data.SearchXYQuery;
using ChyHackerAPI.Models.Service;

namespace ChyHackerAPI.Controllers
{
    public class Qry_UseXYController : BaseController
    {
        /// <summary>
        /// Gets the specified town identifier.
        /// </summary>

        public void Get()

        {
            //Get 預設data
        }

        /// <summary>
        /// 清單
        /// </summary>
        /// <param name="town_id">The town identifier.</param>
        /// <param name="type">The type.</param>
        public void Get(string x, string y, int buffer)
        {
            var input = new SearchXYInput

            {
                X = x,
                Y = y,
                Buffer = buffer
            };
            var service = new SearchXYService(input);
            var result = service.GetLists(input);
            base.JsonResponse(result);
        }
    }
}