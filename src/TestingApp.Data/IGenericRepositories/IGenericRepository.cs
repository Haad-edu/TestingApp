using System.Linq.Expressions;
using TestingApp.Domain.Commons;

namespace TestingApp.Data.IGenericRepositories;

internal interface IGenericRepository<T> where T : Auditable
{
    public Task<T> CreateAsync(T entity);
    public Task<T> Update(T entity);
    public Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
    public Task<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null);
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression,
        string[] includes = null,
        bool isTracking = true);

    public ValueTask SaveChangesAsync();
}
