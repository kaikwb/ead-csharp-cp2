using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ead_csharp_cp2.Models;

[Table("football_teams")]
public class FootballTeam
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name", TypeName = "varchar(100)")]
    public required string Name { get; set; }

    [Required]
    [Column("founded_at")]
    public DateOnly FoundedAt { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("city", TypeName = "varchar(100)")]
    public required string City { get; set; }
    
    [Required]
    [MaxLength(100)]
    [Column("country", TypeName = "varchar(100)")]
    public required string Country { get; set; }
    
    [MaxLength(100)]
    [Column("stadium", TypeName = "varchar(100)")]
    public string? Stadium { get; set; }
    
    [Column("stadium_capacity")]
    public int? StadiumCapacity { get; set; }
}