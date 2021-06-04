using System.IdentityModel.Tokens.Jwt;

namespace ChirpServer.Helpers
{
    public interface IJwtService
    {
        string generateToken(int userId);
        JwtSecurityToken Verify(string jwt);
    }
}