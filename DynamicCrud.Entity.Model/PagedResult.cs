using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCrud.Entity.Model
{
    /// <summary>
    ///     Initialize an instance of <see cref="PagedResult{T}"/>
    /// </summary>
    /// <typeparam name="T">The type</typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// Gets or sets the list of items
        /// </summary>
        public IList<T>? Items { get; set; }

        /// <summary>
        /// Gets or sets total record count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
