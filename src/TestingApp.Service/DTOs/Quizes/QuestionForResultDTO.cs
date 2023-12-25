

using System.ComponentModel.DataAnnotations;
using TestingApp.Domain.Entities.Attachments;
using TestingApp.Domain.Entities.Quizes;

namespace TestingApp.Service.DTOs.Quizes;

public class QuestionForResultDTO
{
    public int Id { get; set; }

    public int QuizId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public ICollection<Answer> Answers { get; set; }
    public ICollection<Attachment> Attachments { get; set; }
}
