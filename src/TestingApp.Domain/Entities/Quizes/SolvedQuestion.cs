using TestingApp.Domain.Commons;

namespace TestingApp.Domain.Entities.Quizes;

public class SolvedQuestion : Auditable
{
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public int AnswerId { get; set; }
    public Answer Answer { get; set; }
    public bool IsCorrect { get; set; }
    public int QuizResultId { get; set; }
}
