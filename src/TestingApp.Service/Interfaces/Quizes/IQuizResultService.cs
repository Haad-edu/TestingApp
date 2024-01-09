using System.Linq.Expressions;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Service.DTOs.Quizes;

namespace TestingApp.Service.Interfaces.Quizes;

public interface IQuizResultService
{
    public Task<QuizResultForViewDTO> CreateAsync(QuizResultForCreationDTO quizResult);
    public Task<IEnumerable<QuizResultForViewDTO>> GetAllAsync(
        PaginationParams @params,
        Expression<Func<QuizResult, bool>> expression = null);
    public Task<QuizResultForViewDTO> GetAsync(Expression<Func<QuizResult , bool>> expression = null); 
}   
