using TutorCabinet.Application.DTOs;

namespace TutorCabinet.Application.Interfaces;

public interface IUserService
{
    Task<Guid> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken = default);
    Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> CheckCredentialsAsync(string email, string password, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateUserDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}