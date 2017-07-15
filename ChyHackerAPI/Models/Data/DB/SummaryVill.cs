namespace ChyHackerAPI.Models.Data.DB
{
    public class SummaryVill : Poly
    {
        public string COUN_NA { get; set; }
        public string TOWN_NA { get; set; }
        public string VLG_NA { get; set; }
        public string POI_Culture { get; set; }
        public string POI_Monuments { get; set; }
        public string POI_Food { get; set; }
        public string POI_landscape { get; set; }
        public string Transportation_NoBus { get; set; }
        public string Transportation_NOsidewalk { get; set; }
        public string Transportation_NotOKsidewalk { get; set; }

        public string VLG_ID { get; set; }
        public string Industry_card { get; set; }
        public string Industry_Nocard { get; set; }
        public string HOTEL_COUNT { get; set; }
        public string HOTEL_COSTUMER { get; set; }
        public string HOTEL_OCCUPANCY { get; set; }
        public string HOTEL_FOREIGNER { get; set; }
    }
}