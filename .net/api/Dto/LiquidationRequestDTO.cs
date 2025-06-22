namespace api.Dto
{
    public class LiquidationRequestDTO
    {
        public int ConsortiumId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
