using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestingApp.Data.IGenericRepositories;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Courses;
using TestingApp.Service.DTOs.Courses;
using TestingApp.Service.Exceptions;
using TestingApp.Service.Extensions;
using TestingApp.Service.Interfaces.Courses;

namespace TestingApp.Service.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository<Course> courseRepository;

        public CourseService(IMapper mapper, IGenericRepository<Course> courseRepository)
        {
            this.mapper = mapper;
            this.courseRepository = courseRepository;
        }

        public async Task<CourseForCreationDTO> CreateAsync(CourseForCreationDTO courseForCreationDTO)
        {
            var exist = await courseRepository.GetAsync(e => e.Name == courseForCreationDTO.Name);
            if (exist != null)
                throw new TestingAppException(400, "Course is already exist");

            var mappedCourse = mapper.Map<Course>(courseForCreationDTO);
            mappedCourse.CreatedAt = DateTime.UtcNow;

            var courses = await courseRepository.CreateAsync(mappedCourse);

            return mapper.Map<CourseForCreationDTO>(courses);
        }

        public async Task<bool> DeleteAsync(long Id)
        {
            var existCourse = await courseRepository.DeleteAsync(i => i.Id == Id);

            if (existCourse == null)
                throw new TestingAppException(404, "Course not found");
            return true;
        }

        public async ValueTask<IEnumerable<CourseForCreationDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null)
        {
            var Courses = courseRepository.GetAll(expression: expression, isTracking: false);

            return mapper.Map<IEnumerable<CourseForCreationDTO>>(await Courses.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<CourseForCreationDTO> GetAsync(Expression<Func<Course, bool>> expression = null)
        {
            var GetCourse = await courseRepository.GetAsync(expression);

            if (GetCourse is null)
                throw new TestingAppException(404, "Course not found ");


            return mapper.Map<CourseForCreationDTO>(GetCourse);
        }

        public async Task<CourseForCreationDTO> UpdateAsync(long Id, CourseForCreationDTO Updatecourse)
        {
            var ExistCourse = await courseRepository.GetAsync(u => u.Id == Id);

            if (ExistCourse is null)
                throw new TestingAppException(404, "Course not found");

            ExistCourse.UpdatedAt = DateTime.UtcNow;
            ExistCourse = await courseRepository.Update(mapper.Map(Updatecourse, ExistCourse));
            return mapper.Map<CourseForCreationDTO>(ExistCourse);
        }
    }
}
