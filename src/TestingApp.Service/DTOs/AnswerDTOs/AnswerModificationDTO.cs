namespace TestingApp.Service.DTOs.AnswerDTOs;

public class AnswerModificationDTO
{
    public string Content { get; set; }
    public string Option { get; set; }
    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }
}
