using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddTransient<IUserRepository, UserRepository>();


builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookServices, BookServices>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderServices, OrderServices>();
builder.Services.AddDbContext<Library214773780Context>(option =>option.UseSqlServer("Server=srv2\\pupils;Database=Library214773780;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();

