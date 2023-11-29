// -----------------------------------------------------------------------
//  <copyright file="ForbiddenAccessException.cs" company="BTS">
//      Copyright  © Believe To Shine.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicCrud.Api.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception used when access is forbidden
    /// </summary>
    [Serializable]
    public class ForbiddenAccessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenAccessException"/> class.
        /// </summary>
        public ForbiddenAccessException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenAccessException"/> class.
        /// </summary>
        /// <param name="message">The message</param>
        public ForbiddenAccessException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenAccessException"/> class.
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="inner">The inner exception</param>
        public ForbiddenAccessException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenAccessException"/> class.
        /// </summary>
        /// <param name="info">The serialization info</param>
        /// <param name="context">The streaming context</param>
        protected ForbiddenAccessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
