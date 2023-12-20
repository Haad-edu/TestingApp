using System.ComponentModel.DataAnnotations;
using TestingApp.Domain.Entities.Quizes;

namespace TestingApp.Service.DTOs.CourseDTOs;

public class CourseModificationDTO
{
    [MaxLength(64)]
    public string Name { get; set; }
    public ICollection<Quiz> Quizes { get; set; }
}
