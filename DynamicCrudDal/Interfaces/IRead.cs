using System.Linq.Expressions;

namespace DynamicCrud.Dal.EF.CF.Interfaces
{
    public interface IRead<T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<List<T>> Find(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate);
    }
}
