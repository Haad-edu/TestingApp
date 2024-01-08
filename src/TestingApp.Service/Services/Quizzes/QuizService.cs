using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestingApp.Data.IGenericRepositories;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Service.DTOs.Quizes;
using TestingApp.Service.Exceptions;
using TestingApp.Service.Extensions;
using TestingApp.Service.Interfaces.Quizes;

namespace TestingApp.Service.Services.QuizServices;

#pragma warning disable
public class QuizService : IQuizService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<Quiz> quizRepository;

    public QuizService(IMapper mapper, IGenericRepository<Quiz> quizRepository)
    {
        this.mapper = mapper;
        this.quizRepository = quizRepository;
    }

    public async Task<QuizForViewDTO> CreateAsync(QuizForCreationDTO quizForCreationDTO)
    {
        var exist = await quizRepository.GetAsync(c => c.Title == quizForCreationDTO.Title);

        if (exist != null)
            throw new TestingAppException(400, "Quiz is already exist");

        var Quizs = await quizRepository.CreateAsync(mapper.Map<Quiz>(quizForCreationDTO));

        return mapper.Map<QuizForViewDTO>(Quizs);
    }

    public async Task<bool> DeleteAsync(long Id)
    {
        var existQuiz = await quizRepository.DeleteAsync(i => i.Id == Id);

        if (existQuiz == null)
            throw new TestingAppException(404, "User not found");
        return true;
    }

    public async ValueTask<IEnumerable<QuizForViewDTO>> GetAllAsync(PaginationParams @params,
        Expression<Func<Quiz,
            bool>> expression = null)
    {
        var Quizes = quizRepository.GetAll(expression: expression, isTracking: false);

        //var pagedQuizzes = await Quizes.ToPagedList(@params).ToListAsync();


        return mapper.Map<IEnumerable<QuizForViewDTO>>(await Quizes.ToPagedList(@params)
            .ToListAsync());
    }

    public async ValueTask<QuizForViewDTO> GetAsync(Expression<Func<Quiz, bool>> expression = null)
    {
        var GetQuiz =  await quizRepository.GetAsync(expression);

        if (GetQuiz is null)
            throw new TestingAppException(404, "Quiz not found ");
        return mapper.Map<QuizForViewDTO>(GetQuiz);

    }

    public async Task<QuizForViewDTO> UpdateAsync(long Id,QuizForCreationDTO Updatequiz)
    {
        var ExistQuiz = await quizRepository.GetAsync(u => u.Id == Id);

        if (ExistQuiz is null)
            throw new TestingAppException(404, "Quiz not found");

        ExistQuiz.UpdatedAt = DateTime.UtcNow;
        ExistQuiz = await quizRepository.Update(mapper.Map(Updatequiz,ExistQuiz));
        return mapper.Map<QuizForViewDTO>(ExistQuiz);

    }
}
