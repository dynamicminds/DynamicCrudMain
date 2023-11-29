using DynamicCrud.Dal.EF.CF.Interfaces;
using DynamicCrud.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DynamicCrud.Dal.EF.CF.Repository
{
    public class BaseRepository<T> : ReadBase<T>, IRepository<T> where T : class
    {
        private readonly DCDbContext dbContext;
        public BaseRepository(DCDbContext dbContext) : base(dbContext)
        {
            //can use the below sample??
            //https://dotnettutorials.net/lesson/unit-of-work-csharp-mvc/
            //for lazy loading.
            //https://stackoverflow.com/questions/68880219/how-to-lazy-inject-repositories-in-unit-of-work-pattern-using-dependency-injecti

            this.dbContext = dbContext;
        }

        public async Task Add(T entity)
        {
            await this.dbContext.Set<T>().AddAsync(entity);
        }

        public async Task AddRange(List<T> entities)
        {
            await this.dbContext.Set<T>().AddRangeAsync(entities);
        }

        public async Task Remove(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
        }

        public async Task RemoveRange(List<T> entities)
        {
            this.dbContext.Set<T>().RemoveRange(entities);
        }

        public async Task Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
    public abstract class ReadBase<T> : IRead<T> where T : class
    {
        private readonly DCDbContext dbContext;
        public ReadBase(DCDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await this.dbContext.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            var result = await this.dbContext.Set<T>().FindAsync(id);
            if (result != null)
            {
                dbContext.Entry(result).State = EntityState.Detached;
            }
            return result;
        }

        public async Task<List<T>> GetAll()
        {
            return await this.dbContext.Set<T>().ToListAsync();
        }
        public async Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await this.dbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        /// <summary>
        ///    Get Items by expression filter
        /// </summary>
        /// <param name="expression">Expression to filter T</param>
        /// <returns>Returns the task of<see cref="IList{T}"/></returns>
        public async Task<IList<T>> GetItemsByExpression(
            Expression<Func<T, bool>> expression)
        {
            var query = this.dbContext.Set<T>().Where(expression).AsQueryable();
            return await query.ToListAsync();
        }

        /// <summary>
        ///     Get Items by page
        /// </summary>
        /// <param name="expression">Expression to filter T</param>
        /// <param name="orderByExpression">Expression to sort order</param>
        /// <param name="decending">The boolean to choose asc or desc</param>
        /// <param name="pageNumber">Skip elements form page</param>
        /// <param name="pageSize">The total page size</param>
        /// <returns>Returns the task of<see cref="IList{T}"/></returns>
        public async Task<PagedResult<T>> GetItemsByPage(
            Expression<Func<T, bool>> expression,
            Expression<Func<T, object>> orderByExpression,
            bool decending = true,
            int pageNumber = 0,
            int pageSize = 100)
        {
            var query = orderByExpression != null ? decending ?
                    this.dbContext.Set<T>().Where(expression)
                        .OrderByDescending(orderByExpression)

                    : this.dbContext.Set<T>().Where(expression)
                       .OrderBy(orderByExpression)

                    : this.dbContext.Set<T>()
                    .Where(expression);

            var skipNumber = (pageNumber - 1) * pageSize;
            return await this.ReturnPagedResponse(skipNumber, pageSize, query.AsNoTracking());
        }
        private async Task<PagedResult<T>> ReturnPagedResponse(int skipNumber, int pageSize, IQueryable<T> query) =>
        new PagedResult<T>
        {
            Items = await query.Skip(skipNumber).Take(pageSize).ToListAsync(),
            TotalCount = await query.CountAsync()
        };
    }
}
