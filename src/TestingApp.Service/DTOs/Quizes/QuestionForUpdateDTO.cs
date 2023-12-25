

using System.ComponentModel.DataAnnotations;

namespace TestingApp.Service.DTOs.Quizes;

public class QuestionForUpdateDTO
{
    public int Id { get; set; }

    public int QuizId { get; set; }

    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }
}
