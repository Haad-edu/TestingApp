

using System.Linq.Expressions;
using TestingApp.Domain.Configurations;
using TestingApp.Service.DTOs.Quizes;

namespace TestingApp.Service.Interfaces.Question;

public interface IQuestionService
{
    public Task<QuestionForResultDTO> CreateAsync(QuestionForCreationDTO questionForCreation);

    public Task<QuestionForResultDTO> UpdateAsync(QuestionForUpdateDTO questionForUpdate);

    public Task<bool> DeleteAsync(int id);

    public Task<QuestionForResultDTO> GetAsync(int id);

    public Task<IEnumerable<QuestionForResultDTO>> GetAllAsync(PaginationParams @params);
}
