using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MietHack_10_2023.Database;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace MietHack_10_2023.Api.Controllers.Auth
{
    [Authorize]
    public class AuthController: ApiController
    {
        private readonly AuthService _authService;
        private readonly DatabaseContext _databaseContext;
        private readonly ILogger _logger;

        public AuthController(
            AuthService authService,
            ILogger logger,
            DatabaseContext databaseContext)
        {
            _authService = authService;
            _logger = logger;
            _databaseContext = databaseContext;
        }

        [HttpPost("~/api/authorize")]
        [AllowAnonymous]
        public async Task<AuthResponseModel> AuthorizeAsync(AuthRequestModel request)
        {
            var (identity, user) = await _authService.AuthorizeAsync(request);
            var (token, expires) = _authService.GenerateToken(identity.Claims);

            var userIdVal = identity.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sid).Value;
            var userId = int.Parse(userIdVal);
            _logger.Information($"User {identity.Name} is authorized");
            var dbUser = await _databaseContext.Users
                .Select(x => new
                {
                    Name = x.Student.FullName,
                    Role = x.Status,
                    Id = x.Id
                })
                .Where(x => x.Id == userId)
                .SingleAsync();

            return new AuthResponseModel
            {
                Name = dbUser.Name,
                Token = token,
                Role = dbUser.Role
            };
        }

        [HttpPost("~/api/authorize/deauth")]
        public void DeAuth()
        {
            var userId = GetUserId();
            var userName = _databaseContext.Users.Single(x => x.Id == userId).Login;
            Response.Headers.Add("Clear-Site-Data", "\"cache\", \"cookies\", \"storage\"");
            _logger.Information($"User {userName} is de-authorized");
        }
    }
}
