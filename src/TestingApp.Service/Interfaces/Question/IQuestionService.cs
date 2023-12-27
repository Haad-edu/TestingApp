using TestingApp.Domain.Configurations;
using TestingApp.Service.DTOs.Quizes;

namespace TestingApp.Service.Interfaces.Question;

public interface IQuestionService
{
    public Task<QuestionForViewDTO> CreateAsync(QuestionForCreationDTO questionForCreation);

    public Task<QuestionForViewDTO> UpdateAsync(QuestionForCreationDTO questionForCreationDTO);

    public Task<bool> DeleteAsync(int id);

    public Task<QuestionForViewDTO> GetAsync(int id);

    public Task<IEnumerable<QuestionForViewDTO>> GetAllAsync(PaginationParams @params);
}
