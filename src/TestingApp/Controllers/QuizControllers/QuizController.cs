using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingApp.Domain.Configurations;
using TestingApp.Service.DTOs.Quizes;
using TestingApp.Service.Interfaces.Quizes;

namespace TestingApp.Controllers.QuizControllers;

[Route("Controller")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly IQuizService quizService;

    public QuizController(IQuizService quizService)
    {
        this.quizService = quizService;
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(QuizForCreationDTO quizForCreationDTO)
           => Ok(await quizService.CreateAsync(quizForCreationDTO));


    [HttpPut("{id}")]
    public async ValueTask<IActionResult> UpdateAsync(long id, QuizForCreationDTO quizForUpdateDTO)
           => Ok(await quizService.UpdateAsync(id, quizForUpdateDTO));


    [HttpGet]
    public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params)
           => Ok(await quizService.GetAllAsync(@params));


    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetAsync([FromRoute] long id)
          => Ok(await quizService.GetAsync(u => u.Id == id));
    
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
           => Ok(await quizService.DeleteAsync(id));
}
