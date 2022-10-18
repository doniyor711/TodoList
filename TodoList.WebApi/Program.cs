using Microsoft.EntityFrameworkCore;
using Serilog;
using TodoList.WebApi.Data;
using TodoList.WebApi.Interfaces.Repositories;
using TodoList.WebApi.Interfaces.Services;
using TodoList.WebApi.Repositories;
using TodoList.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//-> database
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLLocalDb");
builder.Services.AddDbContext<AppDbContext>(dbOptions => {
    dbOptions.UseNpgsql(connectionString);
    dbOptions.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
   loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

//-> Repository Reletions
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//-> Service Reletions
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<IAccountService, AccountService>();
//---> Middlewares
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
