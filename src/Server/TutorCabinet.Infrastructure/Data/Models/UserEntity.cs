namespace TutorCabinet.Infrastructure.Data.Models;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string PasswordHash { get; set; }
}