using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using TestingApp.Data.DbContexts;
using TestingApp.Service.Mappers;
using TestingApp.ServiceExtensions;
using TestingSystem.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services
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
builder.Services.AddCors(options =>
{
    options.AddPolicy("WebApplication",configurePolicy:policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:7006");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
        
    });
});

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

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
