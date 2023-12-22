using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestingApp.Data.DbContexts;
using TestingApp.Data.IGenericRepositories;
using TestingApp.Domain.Commons;

namespace TestingApp.Data.GenericRepositories;

public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _dbSet = appDbContext.Set<T>();
    }

    public async Task<T> CreateAsync(T entity)
    {
        var entry = await _dbSet.AddAsync(entity);
        await SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
    {
        // Find entities that match the deletion condition.
        var entitiesToDelete = await _dbSet.Where(expression).ToListAsync();

        // If there are entities to delete, remove them from the DbSet.
        if (entitiesToDelete != null && entitiesToDelete.Any())
        {
            _dbSet.RemoveRange(entitiesToDelete);

            // Save changes to the database.
            await _appDbContext.SaveChangesAsync();
        }

        return true;
    }
    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true)
    {
        var query = expression is null ? _dbSet : _dbSet.Where(expression);
        if(includes is not null)
            foreach(var include in includes)
                query = query.Include(include);
           
        if(!isTracking)
            query = query.AsNoTracking();

        return query;
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null)
    {
        return await GetAll(expression, includes).FirstOrDefaultAsync();
    }

    public async ValueTask SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<T> Update(T entity)
    {
        var updatedSource = await Task.Run(() => _dbSet.Update(entity));

        await SaveChangesAsync();

        return updatedSource.Entity;
    }
}