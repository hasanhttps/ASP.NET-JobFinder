using JobFinder.DataAccsess.DbContexts;
using JobFinder.Domain.Entities.Concretes;
using JobFinder.DataAccess.Reposiotries.Abstracts;

namespace JobFinder.DataAccess.Reposiotries.Concretes;

public class JobRepository : GenericRepository<Jobs>, IJobRepository {
    public JobRepository(JobFinderDbContext context) : base(context) {

    }
}