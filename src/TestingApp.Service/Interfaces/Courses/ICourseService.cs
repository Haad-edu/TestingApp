using System.Linq.Expressions;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Courses;
using TestingApp.Service.DTOs.Courses;

namespace TestingApp.Service.Interfaces.Courses;

public interface ICourseService
{
    Task<CourseForCreationDTO> CreateAsync(CourseForCreationDTO CourseForCreationDTO);

    Task<CourseForCreationDTO> UpdateAsync(long Id, CourseForCreationDTO UpdateCourse);

    Task<bool> DeleteAsync(long Id);

    ValueTask<IEnumerable<CourseForCreationDTO>> GetAllAsync(
           PaginationParams @params,
           Expression<Func<Course, bool>> expression = null);

    ValueTask<CourseForCreationDTO> GetAsync(Expression<Func<Course,
        bool>> expression = null);
}
