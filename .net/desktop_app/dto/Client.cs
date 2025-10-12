using System.Text.Json.Serialization;
using desktop_app.models;

namespace desktop_app.dto
{
    public class Client
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OccupantType? OccupantType { get; set; }
    }
}
