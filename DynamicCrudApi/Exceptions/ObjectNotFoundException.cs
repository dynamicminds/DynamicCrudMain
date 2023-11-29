// -----------------------------------------------------------------------
//  <copyright file="ObjectNotFoundException.cs" company="BTS">
//      Copyright  © Believe To Shine.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicCrud.Api.Exceptions
{
    using System;
    using System.Data;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception used when we cannot find object in data store
    /// </summary>
    [Serializable]
    public class ObjectNotFoundException : DataException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectNotFoundException"/> class.
        /// </summary>
        public ObjectNotFoundException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message</param>
        public ObjectNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="inner">The inner exception</param>
        public ObjectNotFoundException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectNotFoundException"/> class.
        /// </summary>
        /// <param name="info">The serialization info</param>
        /// <param name="context">The streaming context</param>
        protected ObjectNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}