using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class User
    {
        public int id { get; set; }

        public required string name { get; set; }

        public required string lastName { get; set; }

        public required string email { get; set; }

        public required string password { get; set; }

        public required DocumentType documentType { get; set; }

        [Column(TypeName = "BIGINT")]
        public required long documentNumber { get; set; }

        [Column(TypeName = "BIGINT")]
        public long telephoneNumber { get; set; }

        public Role role { get; set; }

        public bool active { get; set; } = true;
    }
}
