// -----------------------------------------------------------------------
//  <copyright file="AutoMapperExtensions.cs" company="BTS">
//      Copyright  © Believe To Shine.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
namespace DynamicCrud.Api.Mapper
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using AutoMapper;

    /// <summary>
    /// Extensions to AutoMapper
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// Ignore the selector source property mapping in destination.
        /// </summary>
        /// <typeparam name="TSource">any source type</typeparam>
        /// <typeparam name="TDestination">any destination type</typeparam>
        /// <param name="map">mapper object</param>
        /// <param name="selector">property name</param>
        /// <returns>Returns the mapped objects post ignore</returns>
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> map,
            Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }

        /// <summary>
        /// To verify and return the context object.
        /// </summary>
        /// <typeparam name="T">generic return type</typeparam>
        /// <param name="context">Resolution Context</param>
        /// <param name="key">key to check</param>
        /// <returns>returns the dynamic object.</returns>
        public static T? GetValue<T>(this ResolutionContext context, string key)
        {
           return (T?)(context.Items.ContainsKey(key) ? context.Items[key] : default(T));
        }
    }
}
