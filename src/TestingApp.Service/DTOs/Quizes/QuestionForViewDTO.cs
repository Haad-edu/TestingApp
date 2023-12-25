using System.Net.Mail;

namespace TestingApp.Service.DTOs.Quizes;
public class QuestionForViewDTO
{
    public int QuizId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public ICollection<AnswerForViewDTO> Answers { get; set; }

    public ICollection<Attachment> attachments { get; set; }
}
