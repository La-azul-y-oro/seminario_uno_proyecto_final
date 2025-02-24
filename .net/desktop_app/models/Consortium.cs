namespace desktop_app.models
{
    public class Consortium
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string Address { get; set; }
        public bool Active { get; set; } = true;
    }

}
