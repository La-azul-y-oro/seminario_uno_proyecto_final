using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models

{
    public class Concept
    {
        public int Id { get; set; }

        [StringLength(255)]
        public required string Name { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required MovementType Type { get; set; }
        public bool Active { get; set; } = true;
    }
}
