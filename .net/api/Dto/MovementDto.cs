using api.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Dto
{
    public class MovementDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MovementType Type { get; set; }
        public string? Receipt { get; set; }
        public int ConsortiumId { get; set; }
        public string? ConsortiumName { get; set; } = null!;
        public int? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public int ConceptId { get; set; }
        public string? ConceptName { get; set; } = null!;
        public int? FunctionalUnitId { get; set; }
        public string? FunctionalUnitName { get; set; }
        public string? Comment { get; set; }
        public bool Active { get; set; }
    }
}
