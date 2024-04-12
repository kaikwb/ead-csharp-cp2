using System.ComponentModel.DataAnnotations;

namespace ead_csharp_cp2.Dto;

public class FootballTeamGetDto
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    public DateOnly FoundedAt { get; set; }

    [Required]
    [MaxLength(100)]
    public required string City { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string Country { get; set; }
    
    [MaxLength(100)]
    public string? Stadium { get; set; }
    
    public int? StadiumCapacity { get; set; }
}