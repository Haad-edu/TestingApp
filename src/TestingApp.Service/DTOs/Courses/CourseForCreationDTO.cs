using System.ComponentModel.DataAnnotations;
using TestingApp.Domain.Entities.Quizes;

namespace TestingApp.Service.DTOs.Courses;

public class CourseForCreationDTO
{
    [MaxLength(64)]
    public string Name { get; set; }
}
