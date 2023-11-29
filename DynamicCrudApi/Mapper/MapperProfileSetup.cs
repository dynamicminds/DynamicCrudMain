// -----------------------------------------------------------------------
//  <copyright file="MapperProfileSetup.cs" company="BTS">
//      Copyright  © Believe To Shine.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
namespace DynamicCrud.Api.Mapper
{
    using AutoMapper;
    using DynamicCrud.Api.Interfaces;

    /// <summary>
    /// Dynamically setup the object for Auto Mapper profile.
    /// </summary>
    /// <typeparam name="T">Type of profile name to create object.</typeparam>
    public class MapperProfileSetup<T> : IMapperProfileSetup<T>
        where T : class, new()
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MapperProfileSetup{T}" /> class
        /// </summary>
        public MapperProfileSetup()
        {
            this.Mapper = this.GetInstance();
        }

        /// <summary>
        /// Gets or Sets IMapper interface which holds the object of dynamically generated profile.
        /// </summary>
        public IMapper Mapper { get; set; }

        /// <summary>
        ///     Function used to generate a new dynamic <see cref="Profile" /> for IMapper.
        /// </summary>
        /// <returns>Returns an <see cref="IMapper" />instance</returns>
        private IMapper GetInstance()
        {
            var mapperProfile = new MapperConfiguration(cfg =>
            {
                Profile? t = new T() as Profile;
                cfg.AddProfile(t);
            });
            return mapperProfile.CreateMapper();
        }
    }
}