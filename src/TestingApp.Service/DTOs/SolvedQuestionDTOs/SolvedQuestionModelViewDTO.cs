using TestingApp.Domain.Entities.Quizes;

namespace TestingApp.Service.DTOs.SolvedQuestionDTOs;

public class SolvedQuestionModelViewDTO
{
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public int AnswerId { get; set; }
    public Answer Answer { get; set; }
    public bool IsCorrect { get; set; }
    public int QuizResultId { get; set; }
}
