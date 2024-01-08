using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestingApp.Data.IGenericRepositories;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Service.DTOs.Quizes;
using TestingApp.Service.Exceptions;
using TestingApp.Service.Interfaces.Quizes;

namespace TestingApp.Service.Services.Quizzes;

public class AnswerService : IAnswerService
{
    private readonly IGenericRepository<Answer> _repository;
    private readonly IMapper _mapper;
    public AnswerService(IGenericRepository<Answer> repository, IMapper mapper)
    {
        this._repository = repository;
        this._mapper = mapper;
    }
    public async Task<AnswerForViewDTO> CreateAsync(AnswerForCreationDTO answerForCreationDTO)
    {
        var isCreated = await _repository.GetAsync(i => 
            i.Content == answerForCreationDTO.Content); 
        
        if(isCreated != null)
        {
            throw new TestingAppException(404, "Answer is already exsist!");
        }
        var anwer = await _repository.CreateAsync(_mapper.Map<Answer>(answerForCreationDTO));

        return _mapper.Map<AnswerForViewDTO>(anwer);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var isDeleted = await _repository.GetAsync(i => i.Id == id);
        if(isDeleted == null)
        {
            throw new TestingAppException(404, "Answer is not deleted. Becouse this answer not found!");
        }
        
        return await _repository.DeleteAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<AnswerForViewDTO>> GetAllAsync(PaginationParams @params,
        Expression<Func<Answer,
            bool>> expression = null)
    {
        var answers = _repository.GetAll(expression).ToListAsync();

        return _mapper.Map<IEnumerable<AnswerForViewDTO>>(answers);
    }

    public async Task<AnswerForViewDTO> GetAsync(Expression<Func<Answer, 
        bool>> expression)
    {
        var answer = await _repository.GetAsync(expression);
        if(answer == null && answer.IsCorrect == false)
        {
            throw new TestingAppException(404, "Answer is not correct!");
        }

        return _mapper.Map<AnswerForViewDTO>(answer);

    }
}
