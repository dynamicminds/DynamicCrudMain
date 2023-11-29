namespace DynamicCrud.Api.Helpers
{
    using System;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Handles Exceptions for application
    /// </summary>
    public static class GeneralExceptionHandler
    {
        /// <summary>
        /// Logs the exception and returns a 500 code which can be converted to a status code in the controller
        /// </summary>
        /// <param name="ex">Instance of an exception thrown</param>
        /// <param name="logger">Instance of ILogger</param>
        /// <param name="traceId">TraceId from IHttpContextAccessor</param>
        /// <returns>Returns an integer representing a 500 status code</returns>
        public static int HandleGeneralApiException(Exception ex, ILogger logger, string? traceId)
        {
            logger.LogError($"TraceId {traceId} {ex.ToString()}");
            return 500;
        }
    }
}
