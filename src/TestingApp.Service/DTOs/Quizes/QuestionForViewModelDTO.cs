using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp.Domain.Entities.Quizes;

namespace TestingApp.Service.DTOs.Quizes
{
    public class QuestionForViewModelDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
