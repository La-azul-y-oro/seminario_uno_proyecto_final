namespace desktop_app.dto
{
    public class FunctionalUnitRequest
    {
        public required string Name { get; set; }
        public decimal Factor { get; set; }
        public int ConsortiumId { get; set; }
    }
}