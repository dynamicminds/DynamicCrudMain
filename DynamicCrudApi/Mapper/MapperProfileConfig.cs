// -----------------------------------------------------------------------
//  <copyright file="MapperProfileConfig.cs" company="BTS">
//      Copyright  © Believe To Shine.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
namespace DynamicCrud.Api.Mapper
{
    using DynamicCrud.Api.Interfaces;
    using DynamicCrud.Api.Mapper;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// All type of Auto mapper's profile related configurations will come under here.
    /// </summary>
    public static class MapperProfileConfig
    {
        /// <summary>
        /// Register all the mapper profiles to create and inject object in run time.
        /// </summary>
        /// <param name="services">Service collection object to add or register in startup.</param>
        public static void RegisterMapperProfiles(this IServiceCollection services)
        {
            services.AddScoped<IMapperProfileSetup<CrudMapper>, MapperProfileSetup<CrudMapper>>();
        }
    }
}
