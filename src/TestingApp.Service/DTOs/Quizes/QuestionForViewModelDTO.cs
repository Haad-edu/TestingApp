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

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
