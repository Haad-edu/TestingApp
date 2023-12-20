using TestingApp.Domain.Commons;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Domain.Entities.Users;

namespace TestingApp.Service.DTOs.QuizResultDTOs;

public class QuizResultCreationDTO : Auditable
{
    public int CorrectAnswers { get; set; }
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<SolvedQuestion> SolvedQuestions { get; set; }
}
