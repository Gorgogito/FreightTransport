using FreightTransport.Domain.Common;
using System.Linq.Expressions;

namespace FreightTransport.Application.Contracts.Persistence
{

  public interface IAsyncRepository<T> where T : BaseDomainModel
  {

    Task<IReadOnlyList<T>> GetAllAsync();

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                    string? includeString = null,
                                    bool disableTracking = true);
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                    List<Expression<Func<T, object>>>? includes = null,
                                    bool disableTracking = true);

    Task<T> GetByIdAsync(int id);

    Task<T> AddAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task DeleteAsync(T entity);

    void AddEntity(T Entity);

    void UpdateEntity(T Entity);

    void DeleteEntity(T Entity);

  }

}
