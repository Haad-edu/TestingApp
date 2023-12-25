using System.Linq.Expressions;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Service.DTOs.Quizes;

namespace TestingApp.Service.Interfaces.Quizes;
public interface IQuizService
{
    ValueTask<QuizForViewDTO> CreateAsync(QuizForCreationDTO quizForCreationDTO);

    ValueTask<QuizForViewDTO> UpdateAsync(int id, QuizForCreationDTO quizForCreationDTO);

    ValueTask<bool> DeleteAsync(int id);

    ValueTask<IEnumerable<QuizForViewDTO>> GetAllAsync( Expression<Func<Quiz, bool>> expression = null);

    ValueTask<QuizForViewDTO> GetAsync(Expression<Func<Quiz, bool>> expression);


}
