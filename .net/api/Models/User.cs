using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class User
    {
        public int Id { get; set; }

        [Column("first_name")]
        public required string FirstName { get; set; }

        [Column("last_name")]
        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Column("document_type")]
        public DocumentType DocumentType { get; set; }

        [Column("document_number", TypeName = "BIGINT")]
        public required long DocumentNumber { get; set; }

        public required string Phone { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role Role { get; set; }

        public bool Active { get; set; } = true;

        [Column("reset_password_token")]
        public string? ResetPasswordToken { get; set; }

        [Column("reset_token_expiration")]
        public DateTime? ResetTokenExpiration { get; set; }

        public ICollection<UserFunctionalUnit> UserFunctionalUnits { get; set; } = new List<UserFunctionalUnit>();

    }
}
