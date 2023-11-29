namespace DynamicCrud.Dal.EF.CF.Interfaces
{
    public interface IRepository<T> : IRead<T> where T : class
    {
        Task Add(T entity);
        Task AddRange(List<T> entities);
        Task Update(T entity);
        Task Remove(T entity);
        Task RemoveRange(List<T> entities);
    }
}
