namespace TestingApp.Service.DTOs.Quizes;
public  class QuizForViewDTO
{
    public int Id { get; set; }
    public int NumberOfQuestions { get; set; }

    public string Title { get; set; }
    public int TimeToSolveInMinutes { get; set; }
}
