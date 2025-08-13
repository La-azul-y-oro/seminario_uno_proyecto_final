using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Movement
    {
        public int Id { get; set; }

        public required DateTime Date { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public required decimal Amount { get; set; }

        public required MovementType Type { get; set; }

        [StringLength(255)]
        public string? Receipt { get; set; }

        [Column("consortium_id")]
        public required int ConsortiumId { get; set; }
        public Consortium Consortium { get; set; } = null!;

        [Column("supplier_id")]
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        [Column("concept_id")]
        public required int ConceptId { get; set; }
        public Concept Concept { get; set; } = null!;

        [Column("functional_unit_id")]
        public int? FunctionalUnitId { get; set; }
        public FunctionalUnit? FunctionalUnit { get; set; }

        public bool Active { get; set; } = true;

        [StringLength(255)]
        public string? Comment { get; set; }
    }
}
