// -----------------------------------------------------------------------
//  <copyright file="RetryException.cs" company="BTS">
//      Copyright  © Believe To Shine.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicCrud.Api.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception used when the user has made too many attempts
    /// </summary>
    [Serializable]
    public class RetryException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetryException"/> class.
        /// </summary>
        public RetryException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryException"/> class.
        /// </summary>
        /// <param name="message">The message</param>
        public RetryException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryException"/> class.
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="inner">The inner exception</param>
        public RetryException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryException"/> class.
        /// </summary>
        /// <param name="info">The serialization info</param>
        /// <param name="context">The streaming context</param>
        protected RetryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}