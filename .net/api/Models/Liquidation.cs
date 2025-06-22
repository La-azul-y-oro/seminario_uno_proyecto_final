using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Liquidation
    {
        public int Id { get; set; }

        [Column("consortium_id")]
        public int ConsortiumId { get; set; }

        [MaxLength(7)]
        [Column("period")]
        public required string Period { get; set; } // Example: "2025-06"

        [Column("generate_at")]
        public required DateTime GenerateAt { get; set; }

        [Column("expiration_date")]
        public required DateTime ExpirationDate { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Amount { get; set; }

        [Column("generate_by")]
        public int GenerateBy { get; set; }
    }
}
