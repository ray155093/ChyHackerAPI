using ChyHackerAPI.Models.Data.Enum;

namespace ChyHackerAPI.Models.Data.SearchXYQuery
{
    public class SearchXYInput
    {
        public EDataPOIType DataType { get; set; }
        public string X { get; set; }

        public string Y { get; set; }

        public int Buffer { get; set; }
    }
}