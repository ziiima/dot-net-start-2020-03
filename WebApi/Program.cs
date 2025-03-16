using System.Net;
using System.Data;
using WebApi.Migrations;
using WeatherForecast.Controllers;
using BugReport.Controllers;
using BugReport.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// host and port
builder.WebHost.UseKestrel(options =>
{
    options.Listen(IPAddress.Parse("0.0.0.0"), 5291);
});

builder.Services.AddScoped<IDbConnection>(provider =>
{
    var connectionString = "Server=postgresql_container;Port=5432;Database=example;User Id=example;Password=example;";
    return new NpgsqlConnection(connectionString);
});
builder.Services.AddScoped<BugReportRepository>();

var app = builder.Build();
app.UseRouting(); // ルーティングを有効にする
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


if (args.Contains("--migrate"))
{
    var connectionString = "Host=postgresql_container;User Id=example;Password=example;Database=example;Port=5432";
    MigrationExtensions migrationOperation = new MigrationExtensions(connectionString);
    migrationOperation.EnsureConnection();
    migrationOperation.RunMigrations();
}

app.Run();
