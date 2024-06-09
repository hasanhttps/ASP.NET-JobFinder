using JobFinder.DataAccsess.DbContexts;
using JobFinder.Domain.Entities.Concretes;
using JobFinder.DataAccess.Reposiotries.Concretes;
using JobFinder.DataAccsess.Reposiotries.Abstracts;

namespace JobFinder.DataAccsess.Reposiotries.Concretes;

public class CategoryRepository : GenericRepository<Categories>, ICategoryRepository {

    public CategoryRepository(JobFinderDbContext context) : base(context) { 
    
    }
}
