using System.Linq.Expressions;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Service.DTOs.Quizes;

namespace TestingApp.Service.Interfaces.Quizes;

public interface IAnswerService
{
    public Task<AnswerForViewDTO> CreateAsync(AnswerForCreationDTO answerForCreationDTO);
    public Task<AnswerForViewDTO> GetAsync(Expression<Func<Answer,
        bool>> expression);
    public Task<IEnumerable<AnswerForViewDTO>> GetAllAsync(PaginationParams @params,
        Expression<Func<Answer,
            bool>> expression = null);
    public Task<bool> DeleteAsync(long id);
}
