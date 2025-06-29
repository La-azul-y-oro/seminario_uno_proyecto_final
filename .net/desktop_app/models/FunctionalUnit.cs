namespace desktop_app.models
{
    public class FunctionalUnit
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Factor { get; set; }
        public int ConsortiumId { get; set; }
        public Consortium Consortium { get; set; } = null!;
        public bool Active { get; set; } = true;
    }

}