using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingApp.Domain.Configurations;
using TestingApp.Service.DTOs.Quizes;
using TestingApp.Service.Interfaces.Quizes;

namespace TestingApp.Controllers.QuizControllers;

[Route("api/[controller]")]
[ApiController]
public class QuizResultController : ControllerBase
{
    private readonly IQuizResultService quizResultService;
    public QuizResultController(IQuizResultService quizResultService)
    {
        this.quizResultService = quizResultService;
    }
    /// <summary>
    /// Everyone can crearte
    /// </summary>
    /// <param name="courseForCreationDTO"></param>
    /// <returns></returns>

    [HttpPost, Authorize(Roles = "Teacher")]
    public async ValueTask<IActionResult> CreateAsync(QuizResultForCreationDTO courseForCreationDTO)
        => Ok(await quizResultService.CreateAsync(courseForCreationDTO));

    /// <summary>
    /// Get a quiz result {Everyone}
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
        => Ok(await quizResultService.GetAsync(u => u.Id == id));

    /// <summary>
    /// Eveyone can see
    /// </summary>
    /// <param name="params"></param>
    /// <returns></returns>
    [HttpGet]
    public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params)
       => Ok(await quizResultService.GetAllAsync(@params));
}
