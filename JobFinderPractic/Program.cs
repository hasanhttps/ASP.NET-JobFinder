using JobFinderPractic.Registers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// My All Service

builder.AddDbContextServices();
builder.Services.AddRepositoryServices();
builder.Services.AddIdentityConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(
     name: "areas",
     pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
   );

    endpoints.MapControllerRoute(
         name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapDefaultControllerRoute();
});
app.Services.AddRoleServices();

#pragma warning restore ASP0014

app.Run();
