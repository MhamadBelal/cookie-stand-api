namespace CookieStandApi.Models
{
    public class HourlySale
    {
        public int Id { get; set; }
        public int SaleValue { get; set; }
        public int CookieStandId { get; set; }
        public CookieStand? CookieStand { get; set; }
    }
}
