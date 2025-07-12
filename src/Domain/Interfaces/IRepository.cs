using System.Linq.Expressions;
using Domain.Common;

namespace Domain.Interfaces;

public interface IRepository<T, TId> where T : BaseEntity<TId>
{
    Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);

    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T Entity, CancellationToken cancellationToken = default);

    void Update(T entity);

    void Delete(T entity);
}
