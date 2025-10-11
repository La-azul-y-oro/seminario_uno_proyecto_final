using System.Text.Json.Serialization;
using api.Models;

namespace api.Dto
{
    public class ClientFunctionalUnitDto
    {
        public int ClientId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OccupantType OccupantType { get; set; }
    }
}
