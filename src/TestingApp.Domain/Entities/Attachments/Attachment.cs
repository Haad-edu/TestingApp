using TestingApp.Domain.Commons;

namespace TestingApp.Domain.Entities.Attachments;

public class Attachment : Auditable
{
    public string Path { get; set; }

    public int QuestionId { get; set; }
}
