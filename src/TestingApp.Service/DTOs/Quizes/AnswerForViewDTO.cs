namespace TestingApp.Service.DTOs.Quizes;
public  class AnswerForViewDTO
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string Option { get; set; }
    public bool IsCorrect { get; set; }
}
