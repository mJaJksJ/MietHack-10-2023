using MietHack_10_2023.Database.BaseTypes;

namespace MietHack_10_2023.Api.Controllers.Auth
{
    public class AuthResponseModel
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
