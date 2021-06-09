// 03.06.21 Ze'ev
// Handling JWT implementation
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChirpServer.Helpers
{
    public class JwtService : IJwtService
    {
        private string secureKey = "wtf, this is very secure, isnt it?";
        public string generateToken(int userId)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
            var credentials = new SigningCredentials(symmetricSecurityKey, algorithm: SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(issuer: userId.ToString(), audience: null, claims: null, notBefore: null, expires: DateTime.Today.AddDays(1));
            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public JwtSecurityToken Verify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secureKey);
            tokenHandler.ValidateToken(jwt, new TokenValidationParameters { 
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
                }, 
                out SecurityToken validatedToken);
            return (JwtSecurityToken)validatedToken;
        }

        public int WrapJWTSecurityToken(string jwt)
        {
            var token = Verify(jwt);
            return int.Parse(token.Issuer);
        }
    }
}
