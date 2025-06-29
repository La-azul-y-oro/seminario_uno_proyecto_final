namespace desktop_app.models {
    public class Liquidation
    {
        public int Id { get; set; }
        public int ConsortiumId { get; set; }
        public string Period { get; set; } = string.Empty;
        public DateTime GenerateAt { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Amount { get; set; }
        public int GenerateBy { get; set; }
    }
}
