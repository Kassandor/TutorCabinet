using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TutorCabinet.Application.Configuration;
using TutorCabinet.Application.DTOs;
using TutorCabinet.Application.Interfaces;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Infrastructure.Services;

/// <summary>
/// <inheritdoc cref="IJwtProvider"/>
/// </summary>
/// <param name="options"></param>
public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    public TokenPair GenerateTokens(User user)
    {
        var optionsValue = options.Value;
        Claim[] accessClaims = [new("userId", user.Id.ToString()), new("type", "access")];
        Claim[] refreshClaims = [new("userId", user.Id.ToString()), new("type", "refresh")];

        var signingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(optionsValue.SecretKey)),
                SecurityAlgorithms.HmacSha256);

        var accessToken = new JwtSecurityToken(
            signingCredentials: signingCredentials,
            claims: accessClaims,
            expires: DateTime.UtcNow.AddHours(optionsValue.AccessExpireHours)
        );

        var refreshToken = new JwtSecurityToken(
            signingCredentials: signingCredentials,
            claims: refreshClaims,
            expires: DateTime.UtcNow.AddHours(optionsValue.RefreshExpireHours)
        );

        return new TokenPair(
            new JwtSecurityTokenHandler().WriteToken(accessToken),
            new JwtSecurityTokenHandler().WriteToken(refreshToken)
        );
    }
}