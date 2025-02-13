using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class FunctionalUnit
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public required string Name { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public required decimal Balance { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public required long Factor { get; set; }

        public required int ConsortiumId { get; set; }

        public bool Active { get; set; } = true;
}
}
