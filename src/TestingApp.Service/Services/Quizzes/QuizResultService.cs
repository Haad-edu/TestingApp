using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestingApp.Data.IGenericRepositories;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Domain.Entities.Users;
using TestingApp.Service.DTOs.Quizes;
using TestingApp.Service.Exceptions;
using TestingApp.Service.Extensions;
using TestingApp.Service.Interfaces.Quizes;

namespace TestingApp.Service.Services.Quizzes;

public class QuizResultService : IQuizResultService
{
    private readonly IGenericRepository<Quiz> quizRepository;
    private readonly IGenericRepository<QuizResult> quizResultRepository;
    private readonly IGenericRepository<User> userRepository;
    private readonly IGenericRepository<Answer> answerRepository;
    private readonly IGenericRepository<Question> questionRepository;
    private readonly IMapper mapper;

    public QuizResultService(IGenericRepository<Quiz> quizRepository, IGenericRepository<QuizResult> quizResultRepository,
        IGenericRepository<User> userRepository, IMapper mapper,
        IGenericRepository<Answer> answerRepository, IGenericRepository<Question> questionRepository)
    {
        this.quizRepository = quizRepository;
        this.quizResultRepository = quizResultRepository;
        this.userRepository = userRepository;
        this.mapper = mapper;
        this.answerRepository = answerRepository;
        this.questionRepository = questionRepository;
    }
    public async Task<QuizResultForViewDTO> CreateAsync(QuizResultForCreationDTO quizResultDTO)
    {
        var quiz = await quizRepository.GetAsync(q => q.Id == quizResultDTO.QuizId);

        if (quiz is null)
            throw new TestingAppException(404, "Quiz not found");

        var user = await userRepository.GetAsync(u => u.Id == quizResultDTO.UserId);
        if (user is null)
            throw new TestingAppException(404, "User not found");

        var quizResult = mapper.Map<QuizResult>(quizResultDTO);

        foreach (var i in quizResultDTO.SolvedQuestions)
        {
            var question = await questionRepository.GetAsync(q => q.Id == i.QuestionId);
            var answer = await answerRepository.GetAsync(a => a.Id == i.AnswerId);

            if (question.QuizId != quiz.Id)
                throw new TestingAppException(404, "quiz doesn't contains such a question");

            if (answer.QuestionId != question.Id)
                throw new TestingAppException(404, "question doesn't contains. such answer");

            if (answer.IsCorrect)
                quizResult.CorrectAnswers++;
        }

        quizResult.UserId = user.Id;
        quizResult = await quizResultRepository.CreateAsync(quizResult);
        await quizResultRepository.SaveChangesAsync();
        return mapper.Map<QuizResultForViewDTO>(quizResult);
    }

    public async Task<IEnumerable<QuizResultForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<QuizResult, bool>> expression = null)
    {
        var quizResults = quizResultRepository.GetAll(expression: expression, isTracking: false, includes: new string[] { "User", "Quiz" });
        return mapper.Map<List<QuizResultForViewDTO>>(await quizResults.ToPagedList(@params).ToListAsync());
    }

    public async Task<QuizResultForViewDTO> GetAsync(Expression<Func<QuizResult, bool>> expression = null)
    {
        var quizResult = await quizResultRepository.GetAsync(expression);
        if (quizResult is null)
            throw new TestingAppException(404, "QuizResult Not Found");

        return mapper.Map<QuizResultForViewDTO>(quizResult);
    }
}
