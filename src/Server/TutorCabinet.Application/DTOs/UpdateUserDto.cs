using System.ComponentModel.DataAnnotations;

namespace TutorCabinet.Application.DTOs;

public class UpdateUserDto
{
    [Required] public Guid Id { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string Email { get; set; }
    
    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Name { get; set; }
}