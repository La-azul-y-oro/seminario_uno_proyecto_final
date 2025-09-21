namespace api.Dto
{
    public class SupplierRequestDTO
    {
        public long Cuit { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public List<int> Concepts { get; set; } = new List<int>();
    }
}
