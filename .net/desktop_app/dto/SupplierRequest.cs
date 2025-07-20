namespace desktop_app.dto
{
    public class SupplierRequest
    {
        public long Cuit { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public List<int> ConceptIds { get; set; } = new List<int>();
    }
}
