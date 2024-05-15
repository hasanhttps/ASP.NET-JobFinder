using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JobFinder.DataAccsess.DbContexts;
using JobFinder.Domain.Entities.Concretes;
using JobFinder.DataAccess.Reposiotries.Abstracts;
using JobFinder.DataAccess.Reposiotries.Concretes;
namespace JobFinderPractic.Registers;

public static class ServiceRegistration {
    public static void AddDbContextServices(this WebApplicationBuilder builder) {
        builder.Services.AddDbContext<JobFinderDbContext>(options => { 
            options.UseSqlServer(builder.Configuration.GetConnectionString("default")).UseLazyLoadingProxies();
        });
    }

    public static void AddRepositoryServices(this IServiceCollection collection) {
        collection.AddScoped<IJobRepository, JobRepository>();
        collection.AddScoped<AppUserRepository>();
    }

    public static void AddIdentityConfigureServices(this IServiceCollection collection) {
        collection.AddIdentity<AppUser, IdentityRole>(option => {

         
        }).AddEntityFrameworkStores<JobFinderDbContext>()
            .AddDefaultTokenProviders();

     
    }
}
