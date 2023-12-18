using System.ComponentModel.DataAnnotations;
using TestingApp.Domain.Commons;
using TestingApp.Domain.Entities.Quizes;

namespace TestingApp.Domain.Entities.Courses;

public class Course : Auditable
{
    [MaxLength(64)]
    public string Name { get; set; }
    public ICollection<Quiz> Quizes { get; set; }
}
