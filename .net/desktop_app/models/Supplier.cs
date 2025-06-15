namespace desktop_app.models
{
    public class Supplier
    {
        public int Id { get; set; }

        public long Cuit { get; set; }

        public required string Name { get; set; }
        public required string Phone { get; set; }

        public required string Email { get; set; }

        public bool Active { get; set; } = true;

    }
}
