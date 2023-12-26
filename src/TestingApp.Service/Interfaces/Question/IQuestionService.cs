using TestingApp.Domain.Configurations;
using TestingApp.Service.DTOs.Quizes;

namespace TestingApp.Service.Interfaces.Question;

public interface IQuestionService
{
    public Task<QuestionForViewModelDTO> CreateAsync(QuestionForCreationDTO questionForCreation);

    public Task<QuestionForViewModelDTO> UpdateAsync(long id, QuestionForCreationDTO questionForCreationDTO);

    public Task<bool> DeleteAsync(long id);

    public Task<QuestionForViewModelDTO> GetAsync(long id);

    public Task<IEnumerable<QuestionForViewModelDTO>> GetAllAsync(PaginationParams @params);
}
