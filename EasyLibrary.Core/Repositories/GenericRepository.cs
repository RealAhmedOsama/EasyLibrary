using System.Linq.Expressions;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _db = new();
    protected readonly DbSet<T> _dbSet;

    public GenericRepository()
    {
        _dbSet = _db.Set<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(T entity)
    {
        return await _dbSet.FindAsync(entity);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _db.ChangeTracker.Clear();
        _dbSet.Update(entity);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }
}