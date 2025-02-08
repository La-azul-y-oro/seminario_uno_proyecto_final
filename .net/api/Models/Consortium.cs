using System.ComponentModel.DataAnnotations;

namespace api.Models

{
    public class Consortium
    {
        public int Id { get; set; }

        [StringLength(255)]
        public required string Name { get; set; }

        [StringLength(255)]
        public required string Address { get; set; }
        public bool Active { get; set; } = true;
    }

}
