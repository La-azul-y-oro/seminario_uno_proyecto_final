using System.ComponentModel.DataAnnotations;

namespace api.Models

{
    public class Concept
    {
        public int Id { get; set; }

        [StringLength(255)]
        public required string Name { get; set; }
        public bool Active { get; set; } = true;
    }
}
