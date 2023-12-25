using TestingApp.Domain.Commons;

namespace TestingApp.Domain.Entities.Attachments;

public class Attachment : Auditable
{
    public string Path { get; set; }

    public long QuestionId { get; set; }
}
