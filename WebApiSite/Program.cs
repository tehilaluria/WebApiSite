using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddDbContext<Library214773780Context>(option =>option.UseSqlServer("Server=srv2\\pupils;Database=Library214773780;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();

