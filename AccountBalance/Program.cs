using Microsoft.EntityFrameworkCore;
using AccountBalance.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AccountBalanceContext>(o =>
o.UseNpgsql(builder.Configuration.GetConnectionString("AccountBalanceContext"))
.UseSnakeCaseNamingConvention()
.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
.EnableSensitiveDataLogging()
);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
