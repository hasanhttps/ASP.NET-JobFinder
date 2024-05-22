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

    public static async void AddRoleServices(this IServiceProvider collection) {

        using var container = collection.CreateScope();
        var usermanager = container.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = container.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        var adminRole = await roleManager.RoleExistsAsync("Admin");

        if (!adminRole)
            await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });

        var adminUser = await usermanager.FindByNameAsync("Hasan");

        if (adminUser is null) {
            var result = await usermanager.CreateAsync(new AppUser {
                UserName = "Hasan",
                Email = "hasanabdullazad@gmail.com",
                EmailConfirmed = true,
            }, "aHsgd527gY-1");

            if (result.Succeeded) {
                var user = await usermanager.FindByNameAsync("Cavid");
                await usermanager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
