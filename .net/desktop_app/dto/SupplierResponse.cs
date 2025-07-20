
namespace desktop_app.dto
{
    public class SupplierResponse
    {
        public int Id { get; set; }
        public long Cuit { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool? Active { get; set; }
        public List<ConceptResponse>? Concepts { get; set; }
    }
}
