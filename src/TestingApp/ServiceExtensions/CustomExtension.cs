using TestingApp.Data.GenericRepositories;
using TestingApp.Data.IGenericRepositories;
using TestingApp.Domain.Entities.Attachments;
using TestingApp.Domain.Entities.Courses;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Domain.Entities.Users;
using TestingApp.Service.Interfaces.Question;
using TestingApp.Service.Interfaces.Quizes;
using TestingApp.Service.Interfaces.Users;
using TestingApp.Service.Services.QuizServices;
using TestingApp.Service.Services.Users;

namespace TestingApp.ServiceExtensions;
public static class CustomExtension
{
   public static void AddCustomServices(this  IServiceCollection services)
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
        services.AddScoped<IQuestionService , QuestionService>();
        services.AddScoped<IQuizService, QuizService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();


    }

}
