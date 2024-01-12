namespace TestingApp.Service.DTOs.Attachments;

public class AttachmentForCreation
{
    public string Path { get; set; }
    public long QuestionId { get; set; }
    public Stream Stream { get; set; }
}
