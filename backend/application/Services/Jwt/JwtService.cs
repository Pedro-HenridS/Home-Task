using Microsoft.Extensions.Options;
using communication.Interfaces.Token;
using communication.Requests.DTO.TokenDTO;
using domain.Interfaces.Token;

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

        }

        private 
    }
}
