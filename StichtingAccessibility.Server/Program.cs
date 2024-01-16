using Microsoft.EntityFrameworkCore;
using StichtingAccessibility.Server.Models;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("https://localhost:5173");
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StichtingDbContext>(options =>
{
    var connection = String.Empty;
    if (builder.Environment.IsDevelopment())
    {
        builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
        connection = builder.Configuration.GetConnectionString("LocalDev");
    }
    else
    {
        connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
    }
    options.UseSqlServer(connection);
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
