using desktop_app.models;

namespace desktop_app.dto
{
    public class ConceptResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public MovementType Type { get; set; }
        public bool Active { get; set; }
    }
}
