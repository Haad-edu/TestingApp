using TestingApp.Domain.Entities.Quizes;
using TestingApp.Domain.Entities.Users;

namespace TestingApp.Service.DTOs.Quizes;
public class QuizResultForViewDTO
{
    public int CorrectAnswers { get; set; }
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<SolvedQuestion> SolvedQuestions { get; set; }


}
