﻿using AutoMapper;
using TestingApp.Domain.Entities.Courses;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Domain.Entities.Users;
using TestingApp.Service.DTOs.Courses;
using TestingApp.Service.DTOs.Quizes;
using TestingApp.Service.DTOs.Users;

namespace TestingApp.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Course
        CreateMap<Course, CourseForCreationDTO>().ReverseMap();

        //Quizes
        CreateMap<Quiz, QuizForCreationDTO>().ReverseMap();

        //QuizResult
        CreateMap<QuizResult, QuizResultForCreationDTO>().ReverseMap();

        //Answer
        CreateMap<Answer, AnswerForCreationDTO>().ReverseMap();

        //SolvetQuestion
        CreateMap<SolvedQuestion, SolvedQuestionDTO>().ReverseMap();

        //User
        CreateMap<User, UserForCreationDTO>().ReverseMap();
        CreateMap<User, UserForModificationDTO>().ReverseMap();
        CreateMap<User, UserForViewModelDTO>().ReverseMap();
    }
}
