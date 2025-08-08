using application.Services.Jwt;
using communication.Requests.DTO.TokenDTO;
using domain.Interfaces.Token;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Xunit;

namespace application.test.Services.Jwt
{
    public class JwtServiceTest
    {
        private readonly JwtService _jwtService;

        public JwtServiceTest()
        {
            var settings = Options.Create(new IJwtSettings
            {
                Key = "+Y-WvDw*2BS8.mmb2E*(vDK-[m.?wQ9lz3?dQo/.1I;x0p7.8(y5}P@!zom6W",
                Issuer = "Issuer",
                Audience = "Audience"
            });

            _jwtService = new JwtService(settings);
        }

        [Fact]
        public void Execute_GerarTokenComClaimsValidas()
        {

            // Arrange
            var claims = new JwtClaimsDto
            {
                Id = Guid.NewGuid(),
            };

            /*O JwtSecurityTokenHandler instancia um objeto que permite manipular tokens */
            var jwtHandler = new JwtSecurityTokenHandler();

            // Act
            var result = _jwtService.Execute(claims);

            // Assert
            var jwtToken = jwtHandler.ReadJwtToken(result);
            var subclaim = jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub).Value;

            Assert.Equal(claims.Id.ToString(), subclaim);
        }
    }
}
