using TestingApp.Domain.Commons;

namespace TestingApp.Domain.Entities.Quizes
{
    public class Answer : Auditable
    {
        public string Content { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }

        public long QuestionId { get; set; }
    }
}
