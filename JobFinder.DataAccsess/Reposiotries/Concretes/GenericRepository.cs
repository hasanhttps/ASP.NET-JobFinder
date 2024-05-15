using Microsoft.EntityFrameworkCore;
using JobFinder.DataAccsess.DbContexts;
using JobFinder.Domain.Entities.Abstracts;
using JobFinder.DataAccess.Reposiotries.Abstracts;

namespace JobFinder.DataAccess.Reposiotries.Concretes;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new() {
    protected readonly JobFinderDbContext _context;

    public GenericRepository(JobFinderDbContext context) {
        _context = context;
    }

    public async Task AddAsync(T entity) {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        _context.Set<T>().Remove(entity!);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync() {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id) {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(T entity) {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChanges() {
        await _context.SaveChangesAsync();
    }
}
