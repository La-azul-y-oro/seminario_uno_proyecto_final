using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("user_functional_unit")]
    public class UserFunctionalUnit
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int FunctionalUnitId { get; set; }
        public FunctionalUnit FunctionalUnit { get; set; } = null!;
    }
}
