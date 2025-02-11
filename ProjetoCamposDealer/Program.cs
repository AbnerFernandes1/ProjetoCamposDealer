using Microsoft.EntityFrameworkCore;
using ProjetoCamposDealer.Services;
using ProjetoCamposDealer.Services.Interfaces;
using ProjetoDealer.Application.Data.Context;
using ProjetoDealer.Application.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddScoped<IVendaContext, VendaContext>();
builder.Services.AddScoped<IClienteContext, ClienteContext>();
builder.Services.AddScoped<IPersistenceContext, PersistenceContext>();
builder.Services.AddScoped<IProdutoContext, ProdutoContext>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
