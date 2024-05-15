using Microsoft.EntityFrameworkCore;
using JobFinder.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JobFinder.DataAccsess.DbContexts;
public class JobFinderDbContext : IdentityDbContext<AppUser> {

    // Constructor

    public JobFinderDbContext(DbContextOptions<JobFinderDbContext> options) : base(options) {

    }

    // Models

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobFinderDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    // Tabels

    public virtual DbSet<Jobs> Jobs { get; set; }

}