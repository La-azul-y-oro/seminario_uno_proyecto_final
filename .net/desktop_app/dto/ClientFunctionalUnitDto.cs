using System.Text.Json.Serialization;
using desktop_app.models;

namespace desktop_app.dto
{
    public class ClientFunctionalUnitDto
    {
        public int ClientId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OccupantType OccupantType { get; set; }
    }
}
