﻿using System.ComponentModel.DataAnnotations;
using TestingApp.Domain.Commons;

namespace TestingApp.Domain.Entities.Quizes;

public class Quiz : Auditable
{
    public long NumberOfQuestions { get; set; }
    public long CourseId { get; set; }

    [MaxLength(200)]
    public string Title { get; set; }

    public ICollection<Question> Questions { get; set; }
    public int TimeToSolveInMinutes { get; set; }
}
