using Homework_8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Homework_8.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Homework_8.Services;
using System.Security.Claims;
using System.Security.Principal;

namespace Homework_8.Services
{
    public class UserRepository
    {
        private static readonly List<User> users;
        const string ISSUER = "issuing-website-url";
        const string AUDIENCE = "target-website-url";
        const string key = "225e46a6fa5340b1a87b988e4e4326900c8bebf8668648579e91441d1158daf48eb60ad8d035492f8cc8846624eed68c2ee34e08db774af2bd94fb7b99f64ba7";

        private static readonly SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        

        private static string generatedToken = null;
        

        static UserRepository()
        {
            users = new List<User>()
            {
                new User{UserName = "Abhishek" , Password ="1234"},
                new User{UserName = "Arun" , Password ="5678"},
                new User{UserName = "Ajit" , Password ="1357"},
                new User{UserName = "Pradeep" , Password ="2468"},


            };

        }
        public UserRepository()
        {

        }

        internal object GenerateToken(string username, string password)
        {
            //throw new NotImplementedException();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var secToken = new JwtSecurityToken(
                signingCredentials: credentials,
                issuer: ISSUER,
                audience: AUDIENCE,
                claims: new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, username),
                    new Claim(JwtRegisteredClaimNames.UniqueName, password)
                }
            );

            var handler = new JwtSecurityTokenHandler();

            generatedToken = handler.WriteToken(secToken);
            return handler.WriteToken(secToken);
        }



         internal object ValidateToken(string generatedToken, out SecurityToken? validatedToken, out IPrincipal? principal)
            {
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters()
            {
                // Validates token expiry. Setting this to false will not validate token expiry.
                // Shouldn't be turned off, unless the token does not contain expiry (and hence a never expiring one).
                ValidateLifetime = true,

                // Validates the Audience field is the same as the one this application uses
                ValidateAudience = true,

                // Validates the Issuer field is the same as the one this application uses
                ValidateIssuer = true,

                // The expected Issuer value
                ValidIssuer = ISSUER,

                // The expected Audience value
                ValidAudience = AUDIENCE,

                // The same key as the one that generate the token
                IssuerSigningKey = securityKey
            };

            try
            {
                principal = tokenHandler.ValidateToken(generatedToken, validationParameters, out validatedToken);

                return true;
            }
            catch (SecurityTokenException tokenException)
            {

                validatedToken = null;
                principal = null;

                return false;
            }
        }









    }
}
