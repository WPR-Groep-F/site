using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StichtingAccessibility.Server.Data.Setup;
using StichtingAccessibility.Server.Models;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

if (builder.Environment.IsDevelopment())
    {
        builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
    }
    else
    {
        builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:5173", "https://groepf.azurewebsites.net","https://localhost:7024")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
    }



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<StichtingDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7047",
        ValidAudience = "https://localhost:7047",
        IssuerSigningKey =
            new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(
                    "awef98awef978haweof8g7aw789efhh789awef8h9awh89efh89awe98f89uawef9j8aw89hefawef"))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireBeheeder", policy => policy.RequireRole("Beheerder"));
    options.AddPolicy("RequireBedrijf", policy => policy.RequireRole("Bedrijfmedewerker", "Beheerder"));
    options.AddPolicy("RequireDeskundig", policy => policy.RequireRole("Ervaringsdeskundig", "Beheerder"));
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StichtingDbContext>(options =>
{
    var connection = string.Empty;
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//await RoleSetup.InitializeAsync(app.Services);


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();