

using communication.Requests.DTO.TokenDTO;

namespace communication.Interfaces.Token
{
    public interface ITokenService
    {
        public string Execute(JwtClaimsDto claimsDto);
    }
}
