using api.Models;
using System.Text.Json.Serialization;

namespace api.Dto
{
    public class FunctionalUnitClientDto
    {
        public int FunctionalUnitId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OccupantType OccupantType { get; set; }
    }
}
