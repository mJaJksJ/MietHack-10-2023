using Microsoft.AspNetCore.Http;
using Startup;

namespace MjDefaultWithReact.Api.Exceptions
{
    public class AuthException : RussianException
    {
        public AuthException(string russianMessage = "Ошибка авторизации")
            : base(russianMessage, StatusCodes.Status403Forbidden)
        {
        }
    }
}
