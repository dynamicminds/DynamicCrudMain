// -----------------------------------------------------------------------
//  <copyright file="IMapperProfileSetup.cs" company="BTS">
//      Copyright  © Believe To Shine.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
namespace DynamicCrud.Api.Interfaces
{
    using AutoMapper;

    /// <summary>
    /// Interface to dynamically setup the object for Auto Mapper profile.
    /// </summary>
    /// <typeparam name="T">Type of profile name to create object.</typeparam>
    public interface IMapperProfileSetup<T>
        where T : class, new()
    {
        /// <summary>
        /// Gets or Sets IMapper interface which holds the object of dynamically generated profile.
        /// </summary>
        public IMapper Mapper { get; set; }
    }
}
