using TestingApp.Domain.Commons;
using TestingApp.Domain.Entities.Users;

namespace TestingApp.Domain.Entities.Quizes
{
    public class QuizResult : Auditable
    {
        public long CorrectAnswers { get; set; }
        public long QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public ICollection<SolvedQuestion> SolvedQuestions { get; set; }
    }
}
