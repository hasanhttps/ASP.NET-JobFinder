using JobFinder.Domain.Entities.Abstracts;

namespace JobFinder.DataAccess.Reposiotries.Abstracts;

public interface IGenericRepository<T> where T : BaseEntity, new() {
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task Update(T entity);
    Task DeleteAsync(int id);
    Task SaveChanges();
}
