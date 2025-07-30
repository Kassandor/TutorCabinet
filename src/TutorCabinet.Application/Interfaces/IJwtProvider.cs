using TutorCabinet.Core.Entities;

namespace TutorCabinet.Application.Interfaces;

public interface IJwtProvider
{
    string GenerateToken(User user);
}