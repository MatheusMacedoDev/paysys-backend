﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using paysys.webapi.Configuration;
using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Application.Strategies.Token;

public class TokenStrategy : ITokenStrategy
{
    private readonly string SecurityKey;
    private readonly int TokenExpirationHours;

    public TokenStrategy(IOptions<TokenSettings> settings)
    {
        SecurityKey = settings.Value.SecurityKey!;
        TokenExpirationHours = settings.Value.HoursToExpiration;
    }

    public string GenerateToken(UserForLoginTO user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SecurityKey);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[] {
                new Claim(JwtRegisteredClaimNames.Jti, user.userId.ToString()),
                new Claim(ClaimTypes.Name, user.userName),
                new Claim(ClaimTypes.Role, user.userTypeName)
            }),
            Expires = DateTime.UtcNow.AddHours(TokenExpirationHours),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
