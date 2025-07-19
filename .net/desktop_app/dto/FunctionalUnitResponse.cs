namespace desktop_app.dto
{
    public class FunctionalUnitResponse
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required decimal Balance { get; set; }
        public required decimal Factor { get; set; }
        public ICollection<Client> Clients { get; set; } = new List<Client>();
    }
}
