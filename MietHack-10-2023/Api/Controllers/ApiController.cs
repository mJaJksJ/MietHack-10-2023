using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace MietHack_10_2023.Api.Controllers
{
    public class ApiController : Controller
    {
        public ApiController()
        {
        }

        public int GetUserId()
        {
            var id = User.Claims.Single(_ => _.Type == JwtRegisteredClaimNames.Sid).Value;
            return int.Parse(id);
        }
    }
}
