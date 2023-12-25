using System.ComponentModel.DataAnnotations;
using TestingApp.Domain.Entities.Quizes;

namespace TestingApp.Service.DTOs.Quizes;
public class QuizForViewDTO
{
    public int NumberOfQuestions { get; set; }
    public int CourseId { get; set; }

    public string Title { get; set; }

    public ICollection<Question> Questions { get; set; }
    public int TimeToSolveInMinutes { get; set; }
}
