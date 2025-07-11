namespace api.Dto
{
    public class LiquidationDTO
    {
        public int Id { get; set; }
        public required string Period { get; set; }
        public required DateTime ExpirationDate { get; set; }
    }
}
