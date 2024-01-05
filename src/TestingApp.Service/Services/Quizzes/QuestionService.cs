using AutoMapper;
using TestingApp.Data.IGenericRepositories;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Service.DTOs.Quizes;
using TestingApp.Service.Exceptions;
using TestingApp.Service.Extensions;
using TestingApp.Service.Interfaces.Question;

namespace TestingApp.Service.Services.QuizServices;
public class QuestionService : IQuestionService
{
    public readonly IGenericRepository<Question> genericRepository;
    public readonly IMapper mapper;

    public QuestionService(IGenericRepository<Question> genericRepository, IMapper mapper)
    {
        this.genericRepository = genericRepository;
        this.mapper = mapper;
    }

    public async Task<QuestionForViewModelDTO> CreateAsync(QuestionForCreationDTO questionForCreation)
    {
        var createMap = mapper.Map<Question>(questionForCreation);
        createMap.CreatedAt = DateTime.UtcNow;
        var result = await genericRepository.CreateAsync(createMap);
        return mapper.Map<QuestionForViewModelDTO>(result);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var getResult = await genericRepository.GetAsync(x => x.Id == id);
        if (getResult is null)
            throw new TestingAppException(404, "Question is not found");

        await genericRepository.DeleteAsync(x => x.Id == id);
        return true;
    }

    public async Task<IEnumerable<QuestionForViewModelDTO>> GetAllAsync(PaginationParams @params)
    {
        var result = await Task.FromResult(genericRepository.GetAll(expression: null, includes: new string[] { "Answers", "Attachments" }, isTracking: false));
        return mapper.Map<List<QuestionForViewModelDTO>>(result.ToPagedList(@params).ToList());
    }

    public async Task<QuestionForViewModelDTO> GetAsync(long id)
    {
        var result = await genericRepository.GetAsync(x => x.Id == id, new string[] { "Answers", "Attachments" });
        if (result is null)
            throw new TestingAppException(404, "Question is  not found");

        return mapper.Map<QuestionForViewModelDTO>(result);
    }

    public async Task<QuestionForViewModelDTO> UpdateAsync(long id, QuestionForCreationDTO questionForCreationDTO)
    {
        var result = await GetAsync(id);
        if (result is null)
            throw new TestingAppException(404, "Question is  not found");

        var resultMap = mapper.Map<Question>(questionForCreationDTO);
        resultMap.Id = id;
        resultMap.UpdatedAt = DateTime.UtcNow;
        return mapper.Map<QuestionForViewModelDTO>(await genericRepository.Update(resultMap));
    }
}
