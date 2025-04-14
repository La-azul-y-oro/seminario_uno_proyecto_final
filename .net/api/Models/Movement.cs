using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Movement
    {
        public int id {  get; set; }
        public required DateTime date { get; set; }
        public required float amount { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required Type type { get; set; }
        
        [StringLength(255)]
        public string receipt { get; set; }

        [Column("consortium_id")]
        public required int consortiumId { get; set; }

        [Column("supplier_cuit")]
        public required int supplierCuit{ get; set; }

        [Column("concept_id")]
        public required int conceptId { get; set; }

        [Column("functional_unit_id")]
        public required int functionalUnitId { get; set; }
        public bool active { get; set; }

    }
}
