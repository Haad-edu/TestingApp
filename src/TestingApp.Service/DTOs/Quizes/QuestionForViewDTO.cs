using System.ComponentModel.DataAnnotations;

namespace TestingApp.Service.DTOs.Quizes
{
    public class QuestionForViewDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
