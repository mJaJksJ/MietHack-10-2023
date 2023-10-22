using System.Collections.Generic;
using System.Security.Claims;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MjDefaultWithReact.Api.Exceptions;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Startup.Configuration;
using Microsoft.Extensions.Configuration;
using MietHack_10_2023.Database;
using MietHack_10_2023.Database.Models;

namespace MietHack_10_2023.Api.Controllers.Auth
{
    public class AuthService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly AuthConfig _authConfig;

        public AuthService(
            DatabaseContext databaseContext,
            IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _authConfig = configuration.GetSection(AuthConfig.ConfigName).Get<AuthConfig>();
        }

        public async Task<(ClaimsIdentity, User)> AuthorizeAsync(AuthRequestModel request)
        {
            var user = await _databaseContext.Users.SingleOrDefaultAsync(x => x.Login == request.Login)
                ?? throw new AuthException("Пользователь не найден");

            if (user.PasswordHash != PasswordHash(request.Password))
            {
                throw new AuthException();
            }

            return (GenerateIdentity(user), user);
        }

        public (string token, DateTime expires) GenerateToken(IEnumerable<Claim> claims)
        {
            var issueTime = DateTime.Now;
            var expires = issueTime.AddSeconds(_authConfig.JwtLifetime);
            var jwt = new JwtSecurityToken(
                _authConfig.JwtIssuer,
                _authConfig.JwtAudience,
                claims,
                issueTime,
                expires,
                new SigningCredentials(
                    new SymmetricSecurityKey(_authConfig.JwtSecurityKey),
                    "HS256"
                )
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return (encodedJwt, expires);
        }

        private static ClaimsIdentity GenerateIdentity(User user)
        {
            // TODO разобраться в Claim-ах
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Login),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            return new ClaimsIdentity(claims);
        }

        private static string PasswordHash(string password)
        {
            return password;
        }
    }
}
