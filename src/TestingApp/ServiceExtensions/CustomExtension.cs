using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TestingApp.Data.GenericRepositories;
using TestingApp.Data.IGenericRepositories;
using TestingApp.Domain.Entities.Attachments;
using TestingApp.Domain.Entities.Courses;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Domain.Entities.Users;
using TestingApp.Service.Interfaces.Courses;
using TestingApp.Service.Interfaces.Question;
using TestingApp.Service.Interfaces.Quizes;
using TestingApp.Service.Interfaces.Users;
using TestingApp.Service.Services.Courses;
using TestingApp.Service.Services.QuizServices;
using TestingApp.Service.Services.Quizzes;
using TestingApp.Service.Services.Users;

namespace TestingApp.ServiceExtensions;
public static class CustomExtension
{
   public static void AddCustomServices(this IServiceCollection services)
   {
        //Repositories
        services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
        services.AddScoped<IGenericRepository<Course>, GenericRepository<Course>>();
        services.AddScoped<IGenericRepository<Answer>, GenericRepository<Answer>>();
        services.AddScoped<IGenericRepository<Question>, GenericRepository<Question>>();
        services.AddScoped<IGenericRepository<QuizResult>, GenericRepository<QuizResult>>();
        services.AddScoped<IGenericRepository<Quiz>, GenericRepository<Quiz>>();
        services.AddScoped<IGenericRepository<Attachment>, GenericRepository<Attachment>>();

        //Services
        services.AddScoped<IQuizService, QuizService>();
        services.AddScoped<IQuestionService , QuestionService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAnswerService, AnswerService>();
        services.AddScoped<ICourseService, CourseService>();
    }

    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))

            };
        });
    }

    public static void AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(p =>
        {
            p.ResolveConflictingActions(ad => ad.First());
            p.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
            });

            p.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
        });
    }

}
