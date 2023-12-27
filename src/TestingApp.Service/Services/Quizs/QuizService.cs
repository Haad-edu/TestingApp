using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestingApp.Data.DbContexts;
using TestingApp.Data.IGenericRepositories;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Service.DTOs.Quizes;
using TestingApp.Service.Exceptions;
using TestingApp.Service.Interfaces.Quizes;

namespace TestingApp.Service.Services.Quizs;
public class QuizService : IQuizService
{
    private readonly IGenericRepository<Quiz> repository;
    private readonly IMapper mapper;

    public QuizService(IGenericRepository<Quiz> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async ValueTask<QuizForViewDTO> CreateAsync(QuizForCreationDTO creationDTO)
    {
        var quiz = await repository.GetAsync(c => c.Title == creationDTO.Title);

        if (quiz is not null)
            throw new HttpException("Quiz already exist ",400);

        
        var mapping =  await repository.CreateAsync(mapper.Map<Quiz>(creationDTO));

        await repository.SaveChangesAsync();
        
        return mapper.Map<QuizForViewDTO>(quiz);   
    }

    public async ValueTask<bool> DeleteAsync(int Id)
    {
        var delete = await repository.DeleteAsync(d => d.Id == Id);

        if (!delete)
            throw new HttpException("Quiz not found", 404);

        await repository.SaveChangesAsync();
        return true;
    }

    public async ValueTask<IEnumerable<QuizForViewDTO>> GetAllAsync(PaginationParams @params,
        Expression<Func<Quiz, bool>> expression = null)
    {
        var quizes = await repository.GetAll(expression)
            .ToListAsync();

        return mapper.Map<IEnumerable<QuizForViewDTO>>(quizes);
    }

    public async ValueTask<QuizForViewDTO> GetByIdAsync(Expression<Func<Quiz, bool>> expression = null)
    {
        var getId = await repository.GetAsync(expression);

        if (getId is null)
            throw new HttpException("Quiz not found ", 404);
        return mapper.Map<QuizForViewDTO>(getId);
    }

    public async ValueTask<QuizForViewDTO> UpdateAsync(QuizForCreationDTO updateDTO)
    {
        var existQuiz = await repository.GetAsync(u => u.Title == updateDTO.Title);

        if (existQuiz is null)
            throw new HttpException("Quiz not found ", 404);

        existQuiz.UpdatedAt = DateTime.UtcNow;
        var mapping = repository.Update(mapper.Map(updateDTO, existQuiz));
        repository.SaveChangesAsync();

        return mapper.Map<QuizForViewDTO>(mapping);
    }
}
