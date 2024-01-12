using TestingApp.Domain.Entities.Quizes;
using TestingApp.Domain.Entities.Users;

namespace TestingApp.Service.DTOs.Quizes;

public class QuizResultForCreationDTO
{
    public int QuizId { get; set; }
    public int UserId { get; set; }
    public ICollection<SolvedQuestionForCreation> SolvedQuestions { get; set; }
}
