using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TutorCabinet.Application.Configuration;
using TutorCabinet.Application.Interfaces;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Infrastructure.Services;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    public string GenerateToken(User user)
    {
        var optionsValue = options.Value;
        Claim[] claims = [new("userId", user.Id.ToString())];

        var signingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(optionsValue.SecretKey)),
                SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(optionsValue.ExpireHours),
            claims: claims
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}