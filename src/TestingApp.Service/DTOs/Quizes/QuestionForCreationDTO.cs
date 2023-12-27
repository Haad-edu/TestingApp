using System.ComponentModel.DataAnnotations;

namespace TestingApp.Service.DTOs.Quizes;

public class QuestionForCreationDTO
{
    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }
}
