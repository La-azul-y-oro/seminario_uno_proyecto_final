using System.Text.Json.Serialization;

namespace api.Models
{
    public class UserRequest
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DocumentType DocumentType { get; set; }
        public required long DocumentNumber { get; set; }

        public required string Phone { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role Role { get; set; }
    }
}
