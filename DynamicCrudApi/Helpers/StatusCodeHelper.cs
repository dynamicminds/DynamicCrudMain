namespace DynamicCrud.Api.Helpers
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Helper class for returning StatusCodes from API
    /// </summary>
    public static class StatusCodeHelper
    {
        /// <summary>
        /// Creates an ObjectResult with a status code and error parameter in JSON
        /// </summary>
        /// <param name="statusCode">The status code we are returning, see <see cref="StatusCodes"/> for a list of valid codes</param>
        /// <param name="message">The message to include in the JSON response</param>
        /// <param name="isError">Value indicating whether the object result is for an error or not, if true the ObjectResult contains an error property, otherwise a message property</param>
        /// <returns>Returns a new <see cref="ObjectResult"/> with the proper status code and value object</returns>
        public static ObjectResult GetObjectResult(int statusCode, string message, bool isError = true)
        {
            object newObject;

            if (isError)
            {
                newObject = new
                {
                    statusCode,
                    error = message
                };
            }
            else
            {
                newObject = new
                {
                    statusCode,
                    message
                };
            }

            var objectResult = new ObjectResult(newObject) { StatusCode = statusCode };

            return objectResult;
        }

        /// <summary>
        /// Creates an ObjectResult object with a status code and concatenates the JSONString passed in
        /// </summary>
        /// <param name="jsonString">The JSON to concatenate to the object result object</param>
        /// <param name="statusCode">The status code</param>
        /// <returns>Returns a new <see cref="ObjectResult"/> with the proper status code and JSON body</returns>
        public static ObjectResult GetObjectResult(string jsonString, int statusCode)
        {
            object newObject = new
            {
                statusCode
            };

            var statusCodeObject = JObject.FromObject(newObject);
            JObject jsonToConcat;

            try
            {
                jsonToConcat = JObject.Parse(jsonString);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Could not parse json string: {jsonString}");
            }

            statusCodeObject.Merge(jsonToConcat);

            var objectResult = new ObjectResult(statusCodeObject) { StatusCode = statusCode };

            return objectResult;
        }
    }
}
