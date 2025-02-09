namespace api.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Supplier
{
    public int Id { get; set; }

    [Column(TypeName = "BIGINT")]
    [Range(1000000000, 99999999999, ErrorMessage = "CUIT must contain 11 digits")]
    public long Cuit { get; set; }

    [StringLength(255)]
    public required string Name { get; set; }

    [Column(TypeName = "BIGINT")]
    public long Phone { get; set; }

    [StringLength(255)]
    [EmailAddress]
    public required string Email { get; set; }
    
    public bool Active { get; set; } = true;
}
