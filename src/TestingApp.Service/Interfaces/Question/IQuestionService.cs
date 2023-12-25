using TestingApp.Domain.Configurations;
using TestingApp.Service.DTOs.Quizes;

namespace TestingApp.Service.Interfaces.Question;

public interface IQuestionService
{
    public Task<QuestionForViewModelDTO> CreateAsync(QuestionForCreationDTO questionForCreation);

    public Task<QuestionForViewModelDTO> UpdateAsync(QuestionForCreationDTO questionForCreationDTO);

    public Task<bool> DeleteAsync(int id);

    public Task<QuestionForViewModelDTO> GetAsync(int id);

    public Task<IEnumerable<QuestionForViewModelDTO>> GetAllAsync(PaginationParams @params);
}
