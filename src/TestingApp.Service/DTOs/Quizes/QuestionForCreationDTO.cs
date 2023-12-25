using System.ComponentModel.DataAnnotations;
using TestingApp.Domain.Entities.Attachments;
using TestingApp.Domain.Entities.Quizes;

namespace TestingApp.Service.DTOs.Quizes;

public class QuestionForCreationDTO
{
    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }
}
