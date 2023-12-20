using TestingApp.Domain.Entities.Quizes;
using TestingApp.Domain.Entities.Users;

namespace TestingApp.Service.DTOs.QuizResultDTOs;

public class QuizResultModelViewDTO
{
    public int CorrectAnswers { get; set; }
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<SolvedQuestion> SolvedQuestions { get; set; }
    public DateTime CreatedAt { get; set; }
}
