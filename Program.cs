using Microsoft.EntityFrameworkCore;
using ProjetoSZ.Context;
using ProjetoSZ.Services;
using Schutzens.Models;
using Schutzens.Repositories;
using Schutzens.Repositories.Interfaces;
using Schutzens.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SchutzenDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EsteticaDatabase")));

builder.Services.AddScoped<ProjetoSZ.Services.IUserService, UserService>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));


builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

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
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
