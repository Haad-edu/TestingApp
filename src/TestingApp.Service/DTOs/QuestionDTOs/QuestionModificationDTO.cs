using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using TestingApp.Domain.Entities.Quizes;

namespace TestingApp.Service.DTOs.QuestionDTOs;

public class QuestionModificationDTO
{
    public int QuizId { get; set; }

    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public ICollection<Answer> Answers { get; set; }
    public ICollection<Attachment> Attachments { get; set; }
}
