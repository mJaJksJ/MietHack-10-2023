using Microsoft.AspNetCore.Http;
using System;

namespace Startup
{
    /// <inheritdoc/>
    public class RussianException : Exception
    {
        private string RussianMessage { get; }
        /// <summary>
        /// Http код ошибки
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// .ctor
        /// </summary>
        protected RussianException(
            string russianMessage,
            int statusCode = StatusCodes.Status500InternalServerError)
        {
            RussianMessage = russianMessage;
            StatusCode = statusCode;
        }

        /// <inheritdoc/>
        public override string Message => RussianMessage;
    }
}
