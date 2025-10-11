using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class UserFunctionalUnit
    {
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Column("functional_unit_id")]
        public int FunctionalUnitId { get; set; }
        public FunctionalUnit FunctionalUnit { get; set; } = null!;

        [Column("occupant_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OccupantType OccupantType { get; set; }
    }
}
