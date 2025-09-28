namespace desktop_app.models
{
    public class Concept
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public MovementType Type { get; set; }
        public bool Active { get; set; }

    }
}
