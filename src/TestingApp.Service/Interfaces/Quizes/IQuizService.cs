using System.Linq.Expressions;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Service.DTOs.Quizes;

namespace TestingApp.Service.Interfaces.Quizes;
public interface IQuizService
{
    Task<QuizForViewDTO> CreateAsync(QuizForCreationDTO quizForCreationDTO);

    Task<QuizForViewDTO> UpdateAsync(long Id,QuizForCreationDTO Updatequiz);

    Task<bool> DeleteAsync(long Id);

    ValueTask<IEnumerable<QuizForViewDTO>> GetAllAsync(
           PaginationParams @params,
           Expression<Func<Quiz, bool>> expression = null );

    ValueTask<QuizForViewDTO> GetAsync(Expression<Func<Quiz,
        bool>> expression = null);

}
