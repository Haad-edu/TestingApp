using System.ComponentModel.DataAnnotations;
using TestingApp.Domain.Entities.Quizes;

namespace TestingApp.Service.DTOs.Quizes;

public class QuizForCreationDTO
{
    public int NumberOfQuestions { get; set; }

    [MaxLength(200)]
    public string Title { get; set; }
    public int TimeToSolveInMinutes { get; set; }
}
