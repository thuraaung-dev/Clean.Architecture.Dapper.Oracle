using ADAA.ADP.Application.Contracts.Identity;
using ADAA.ADP.Application.Models.Authentication;
using ADP.ADAA.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;

namespace ADP.ADAA.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            const string LDAP_DOMAIN = "auh.police";

            using (var context = new PrincipalContext(ContextType.Domain, LDAP_DOMAIN, "", ""))
            {
                if (!context.ValidateCredentials(request.UserName, request.Password))
                {
                    throw new Exception($"Credentials for '{request.UserName} aren't valid'.");
                }
                else
                {
                    var user = new ApplicationUser();
                    user.Email = request.UserName;
                    user.FirstName = request.UserName;
                    user.LastName = request.UserName;
                    user.UserName = request.UserName;
                    user.EmailConfirmed = true;

                    JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

                    AuthenticationResponse response = new AuthenticationResponse
                    {
                        Id = user.Id,
                        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                        Email = user.Email,
                        UserName = user.UserName
                    };

                    return response;
                }
            }
        }

        private Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return Task.FromResult(jwtSecurityToken);
        }
    }
}
