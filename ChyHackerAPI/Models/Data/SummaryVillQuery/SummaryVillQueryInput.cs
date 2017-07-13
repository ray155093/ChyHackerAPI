using ChyHackerAPI.Models.Data.Enum;

namespace ChyHackerAPI.Models.Data.SummaryVillQuery
{
    public class SummaryVillInput
    {
        /// <summary>
        /// 資料類型
        /// </summary>
        public EDataType DataType { get; set; }

        /// <summary>
        /// 縣市代碼
        /// </summary>
        public string Coun_ID { get; set; }

        /// <summary>
        /// 縣市代碼
        /// </summary>
        public string Coun_NA { get; set; }

        /// <summary>
        /// 鄉鎮代碼
        /// </summary>
        public string Town_ID { get; set; }

        /// <summary>
        /// 村里代碼
        /// </summary>
        public string Vill_ID { get; set; }

        /// <summary>
        /// 統計區代碼
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 查詢年分
        /// </summary>
        public int QueryYear { get; set; }

        /// <summary>
        /// 查詢月份
        /// </summary>
        public int QueryMonth { get; set; }

        /// <summary>
        /// 查詢等級
        /// </summary>
        public EQueryLevel QueryLevel { get; set; }

        /// <summary>
        /// 資料的地理格式
        /// </summary>
        /// <value>
        /// The type of the geometry.
        /// </value>
        public EGeometryType GeometryType { get; set; }

        /// <summary>
        ///擴充屬性 讓service 決定實作方式使用
        /// </summary>
        /// <value>
        /// The type of the service implement.
        /// </value>
        public string ServiceImplementType { get; set; }
    }
}