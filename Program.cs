using Microsoft.EntityFrameworkCore;
using ProjetoSZ.Context;
using ProjetoSZ.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SchutzenDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EsteticaDatabase")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
