using TestingApp.Domain.Entities.Quizes;

namespace TestingApp.Service.DTOs.Quizes;

public class SolvedQuestionDTO
{
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public int AnswerId { get; set; }
    public Answer Answer { get; set; }
    public bool IsCorrect { get; set; }
    public int QuizResultId { get; set; }
}
