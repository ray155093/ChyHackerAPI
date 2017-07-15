using ChyHackerAPI.Models.Data.Enum;
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
        /// Gets xy to data.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="type">The type = POI、Fc.</param>
        public void Get(string x, string y, int buffer, EDataPOIType type)
        {
            var input = new SearchXYInput
            {
                X = x,
                Y = y,
                Buffer = buffer,
                DataType = type
            };
            var service = new SearchXYService(input);
            var result = service.GetLists(input);
            base.JsonResponse(result);
        }

        public void Get(EDataPOIType type)
        {
            var input = new SearchXYInput
            {
                DataType = type
            };
            var service = new SearchXYService(input);
            var result = service.GetLists(input);
            base.JsonResponse(result);
        }
    }
}