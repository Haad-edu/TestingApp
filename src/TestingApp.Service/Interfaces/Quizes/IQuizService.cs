using System.Linq.Expressions;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Service.DTOs.Quizes;

namespace TestingApp.Service.Interfaces.Quizes;
public interface IQuizService
{

    ValueTask<QuizForViewDTO> CreateAsync(QuizForCreationDTO creationDTO);

    ValueTask<QuizForViewDTO> UpdateAsync(QuizForCreationDTO updateDTO);

    ValueTask<IEnumerable<QuizForViewDTO>> GetAllAsync(PaginationParams @params,
        Expression<Func<Quiz, bool>> expression = null);

    ValueTask<QuizForViewDTO> GetByIdAsync(Expression<Func<Quiz, bool>>expression = null);

    ValueTask<bool> DeleteAsync(int Id);
}
