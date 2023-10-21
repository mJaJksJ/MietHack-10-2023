namespace Startup.Configuration
{
    public class AuthConfig
    {
        /// <summary>
        /// Имя в конфиге
        /// </summary>
        public static string ConfigName => "Auth";

        /// <summary>
        /// Секретный ключ токена
        /// </summary>
        public byte[] JwtSecurityKey { get; set; }

        /// <summary>
        /// Время жизни токена, сек
        /// </summary>
        public int JwtLifetime { get; set; }

        /// <summary>
        /// Издатель токена
        /// </summary>
        public string JwtIssuer { get; set; }

        /// <summary>
        /// Пользователи токена
        /// </summary>
        public string JwtAudience { get; set; }
    }
}
