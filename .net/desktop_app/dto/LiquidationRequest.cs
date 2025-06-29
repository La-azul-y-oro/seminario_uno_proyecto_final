namespace desktop_app.dto
{
    public class LiquidationRequest
    {
        public int ConsortiumId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
