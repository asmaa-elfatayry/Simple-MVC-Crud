using Microsoft.EntityFrameworkCore;
using Task.IRepos;
using Task.Models;
using Task.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<EmpTaskContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("con")));

// Register repository
builder.Services.AddScoped<IRepoEmployee, RepoEmployee>();
builder.Services.AddScoped<IRepouser, RepoUser>();
builder.Services.AddScoped<IRepoDepartment, RepoDepartment>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");



using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EmpTaskContext>();
    context.Database.EnsureCreated();
    context.SeedData();
}

app.Run();
