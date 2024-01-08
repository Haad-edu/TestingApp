using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using TestingApp.Domain.Configurations;
using TestingApp.Service.DTOs.Quizes;
using TestingApp.Service.Interfaces.Quizes;

namespace TestingApp.Controllers.QuizControllers
{
    [Route("controller")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            this._answerService = answerService;   
        }

        [HttpPost("api/Answer/Teacher")]
        public async Task<ActionResult<bool>> CreatAsync(AnswerForCreationDTO answerForCreationDTO)
        {
            await _answerService.CreateAsync(answerForCreationDTO);
            return Ok(true);
        }

        [HttpDelete("api/Answer/Teacher")]
        public async Task<ActionResult<bool>> DeleteAsync(long id)
            => Ok(await _answerService.DeleteAsync(id));

        [HttpGet("api/Answer/All/id")]
        public async Task<ActionResult<AnswerForViewDTO>> GetAsync(long id)
            => Ok(await _answerService.GetAsync(i => i.Id == id));

        [HttpGet("api/Answer/All")]
        public async Task<IActionResult> GetAll(PaginationParams @params)
            => Ok(await _answerService.GetAllAsync(@params));
        
        
    }
}
