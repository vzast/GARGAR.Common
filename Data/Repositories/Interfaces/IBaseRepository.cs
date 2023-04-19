using System.Linq.Expressions;

namespace Data.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> Table { get; }

        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(params object[] key);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task CreateAsync(T entity, string userId);

        Task UpdateAsync(T entity, string userId);

        Task RemoveAsync(T entity);

        Task Save();
    }
}