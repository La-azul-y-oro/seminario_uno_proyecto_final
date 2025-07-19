namespace desktop_app.dto
{
    public class ConsortiumResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public ICollection<FunctionalUnitResponse> FunctionalUnits { get; set; } = new List<FunctionalUnitResponse>();
    }
}
