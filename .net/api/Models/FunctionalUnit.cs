using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("functional_unit")]
    public class FunctionalUnit
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public required string Name { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public required decimal Balance { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public required float Factor { get; set; }

        [Column("consortium_id")]
        public required int ConsortiumId { get; set; }
        public Consortium Consortium { get; set; } = null!;

        public bool Active { get; set; } = true;

        public ICollection<UserFunctionalUnit> UserFunctionalUnits { get; set; } = new List<UserFunctionalUnit>();

    }
}
