// -----------------------------------------------------------------------
//  <copyright file="HttpException.cs" company="BTS">
//      Copyright  © Believe To Shine.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicCrud.Api.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///     Exception used when there is a bad request
    /// </summary>
    [Serializable]
    public class HttpException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HttpException" /> class.
        /// </summary>
        public HttpException()
            : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HttpException" /> class.
        /// </summary>
        /// <param name="statusCode">the HTTP status code</param>
        /// <param name="message">The message</param>
        public HttpException(int statusCode, string message)
            : base(message)
        {
            this.StatusCode = statusCode;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HttpException" /> class.
        /// </summary>
        /// <param name="message">The exception message</param>
        public HttpException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HttpException" /> class.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">The inner exception</param>
        public HttpException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HttpException" /> class.
        /// </summary>
        /// <param name="serializationInfo">The serialization info</param>
        /// <param name="streamingContext">The streaming context</param>
        protected HttpException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets or sets the HTTP status code
        /// </summary>
        public int StatusCode { get; set; }
    }
}