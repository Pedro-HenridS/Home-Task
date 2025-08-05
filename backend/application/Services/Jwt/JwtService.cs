using communication.Interfaces.Token;
using communication.Requests.DTO.TokenDTO;
using domain.Interfaces.Token;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace application.Services.Jwt
{
    public class JwtService : ITokenService
    {
        private readonly IJwtSettings _jwtSettings;

        public JwtService(IOptions<IJwtSettings> jwtSettings)
        {

            _jwtSettings = jwtSettings.Value;
        }
        public string Execute(JwtClaimsDto request)
        {
            var securityKey = SymmetricSecurityKey();
            var credentials = SigningCredentials(securityKey);
            var claims = Claims(request);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
                );

            var jwtString = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtString;
        }

        private SymmetricSecurityKey SymmetricSecurityKey()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            return securityKey;
        }

        private SigningCredentials SigningCredentials(SymmetricSecurityKey securityKey)
        {
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            return credentials;
        }

        private List<Claim> Claims(JwtClaimsDto claimsDto)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, claimsDto.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            return claims;
        }
    }
}
