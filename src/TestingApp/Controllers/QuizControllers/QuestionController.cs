using Microsoft.AspNetCore.Mvc;
using TestingApp.Domain.Configurations;
using TestingApp.Service.DTOs.Quizes;
using TestingApp.Service.Interfaces.Question;

namespace TestingApp.Controllers.QuizControllers;
[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService questionService;

    public QuestionController(IQuestionService questionService)
    {
        this.questionService = questionService;
    }

    [HttpPost] // mana shu 2 tasi conflict beradi men chiqdim
    public async ValueTask<IActionResult> CreateAsync(QuestionForCreationDTO quizForCreation)
        => Ok(await questionService.CreateAsync(quizForCreation));


    [HttpPut("Id")]
    public async ValueTask<IActionResult> UpdateAsync(long Id, QuestionForCreationDTO QuizforUpdate)
        => Ok(await questionService.UpdateAsync(Id, QuizforUpdate));


    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await questionService.GetAllAsync(@params));


    [HttpGet("Id")]
    public async ValueTask<IActionResult> GetAsync([FromRoute] long Id)
        => Ok(await questionService.GetAsync(Id));


    [HttpDelete("Id")]
    public async ValueTask<IActionResult> DeleteAsync(long Id)
        => Ok(await questionService.DeleteAsync(Id));

}
