using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingApp.Domain.Configurations;
using TestingApp.Service.DTOs.Courses;
using TestingApp.Service.Interfaces.Courses;

namespace TestingApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService courseService;
    public CourseController(ICourseService courseService)
    {
        this.courseService = courseService;
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(CourseForCreationDTO courseForCreationDTO)
          => Ok(await courseService.CreateAsync(courseForCreationDTO));


    [HttpPut("{id}")]
    public async ValueTask<IActionResult> UpdateAsync(long id, CourseForCreationDTO courseForUpdateDTO)
           => Ok(await courseService.UpdateAsync(id, courseForUpdateDTO));

    [HttpGet]
    public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params)
           => Ok(await courseService.GetAllAsync(@params));


    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetAsync([FromRoute] long id)
    {
      return   Ok(await courseService.GetAsync(u => u.Id == id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
           => Ok(await courseService.DeleteAsync(id));
}
