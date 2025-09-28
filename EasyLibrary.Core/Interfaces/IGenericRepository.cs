namespace EasyLibrary.Core.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(T entity);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}