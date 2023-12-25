using TestingApp.Domain.Commons;

namespace TestingApp.Domain.Entities.Quizes;

public class SolvedQuestion : Auditable
{
    public long QuestionId { get; set; }
    public Question Question { get; set; }
    public long AnswerId { get; set; }
    public Answer Answer { get; set; }
    public bool IsCorrect { get; set; }
    public long QuizResultId { get; set; }
}
