using api.Models;
using System.Text.Json.Serialization;

namespace api.Dto
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
