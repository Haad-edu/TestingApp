using System.ComponentModel.DataAnnotations;

namespace TestingApp.Service.DTOs.Quizes;

public class AnswerForCreationDTO
{
    public required string Content { get; set; }
    [MaxLength(2)]
    public required string Option { get; set; }
    public  bool IsCorrect { get; set; }
}
