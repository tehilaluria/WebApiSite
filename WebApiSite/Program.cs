using Entities;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using PresidentsApp.Middlewares;
using Repositories;
using Services;
using WebApiSite;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookServices, BookServices>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderServices, OrderServices>();
builder.Services.AddTransient<IRateRepository, RateRepository>();
builder.Services.AddTransient<IRateServices, RateServices>();
builder.Services.AddDbContext<BookStore325569796Context>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyBookStore")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Host.UseNLog();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
//app.ErrorHandlingMiddleware();
app.UseMiddleware<RequestLoggerMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

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

