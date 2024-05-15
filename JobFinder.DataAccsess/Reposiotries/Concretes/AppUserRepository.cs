using JobFinder.DataAccsess.DbContexts;
using JobFinder.Domain.Entities.Concretes;
using JobFinder.DataAccess.Reposiotries.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.DataAccess.Reposiotries.Concretes;

public class AppUserRepository {
    protected readonly JobFinderDbContext _context;

    public AppUserRepository(JobFinderDbContext context) {
        _context = context;
    }

    public async Task AddAsync(AppUser entity) {
        await _context.Set<AppUser>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        var entity = await _context.Set<AppUser>().FirstOrDefaultAsync(x => x.Id == id.ToString());
        _context.Set<AppUser>().Remove(entity!);
        await _context.SaveChangesAsync();
    }

    public async Task<List<AppUser>> GetAllAsync() {
        return await _context.Set<AppUser>().ToListAsync();
    }

    public async Task<AppUser> GetByIdAsync(int id) {
        return await _context.Set<AppUser>().FirstOrDefaultAsync(x => x.Id == id.ToString());
    }

    public async Task Update(AppUser entity) {
        _context.Set<AppUser>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChanges() {
        await _context.SaveChangesAsync();
    }
}