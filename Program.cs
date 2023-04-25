using System.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using dot7.API.Data.Entities;
using Npgsql;
using DbUp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<WeatherDbContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectionString:DemoDbCon"]));

//For PostgresConnection
var connectionString = builder.Configuration["ConnectionStrings:Postgres"];
builder.Services.AddScoped<IDbConnection>(db => new NpgsqlConnection(connectionString));

//for Dbup
// EnsureData
EnsureDatabase.For.PostgresqlDatabase(connectionString);
var  upgrader = DeployChanges.To
    .PostgresqlDatabase(connectionString)
    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
    .LogToConsole()
    .WithScriptsFromFileSystem("Migration")
    .Build();
var result =upgrader.PerformUpgrade();
if(result.Successful)
{
    Console.WriteLine("data base upgreded");
}
else
{
    Console.WriteLine("database upgrade fail");
}

//For Dependency Injection of Repository
builder.Services.AddScoped<userRepository>();
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

// app.UseAuthorization();

app.MapControllers();

app.Run();
