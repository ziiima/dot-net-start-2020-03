using System.Net;
using WebApi.Migrations;
using WeatherForecast.Controllers;

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
