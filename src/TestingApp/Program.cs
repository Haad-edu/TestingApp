using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using TestingApp.Data.DbContexts;
using TestingApp.Domain.Enums;
using TestingApp.Service.Mappers;
using TestingApp.ServiceExtensions;
using TestingSystem.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

#pragma warning disable

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services


//Add Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AllPolicy", policy => policy.RequireRole(
        Enum.GetName(UserRole.Admin),
        Enum.GetName(UserRole.User)));

    options.AddPolicy("UserPolicy", policy => policy.RequireRole(
        Enum.GetName(UserRole.Admin),
        Enum.GetName(UserRole.User)));

    options.AddPolicy("AdminPolicy", policy => policy.RequireRole(
        Enum.GetName(UserRole.Admin)));

    options.AddPolicy("TecherPolicy", policy => policy.RequireRole(
        Enum.GetName(UserRole.Teacher)));
});

// Serilog
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddCustomServices();

//Register Jwt
builder.Services.ConfigureJwt(builder.Configuration);

// Register Swagger Service
builder.Services.AddSwaggerService();

// Register Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
