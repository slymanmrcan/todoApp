using MVC.Repositories;

namespace MVC.Services;

public class GenericService<T>(IGenericRepository<T> repository) : IGeneriService<T>
    where T : class
{
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await repository.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        await repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    
}