using APIImplementation.Models.Responses;
using APIImplementation.Repositories.Interfaces;
using APIImplementation.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace APIImplementation.Services
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IScheduleService _scheduleService;

        public CourseService(ICourseRepository courseRepository, IScheduleService scheduleService)
        {
            _courseRepository = courseRepository;
            _scheduleService = scheduleService;
        }

        public CourseResponse GetById(int id)
        {
            var course= _courseRepository.GetById(id);
            if(course == null)
            {
                throw new ArgumentException("Enter valid courseId");
            }
            return new CourseResponse
            {
                Id = id,
                Name = course.Name,
                TotalDuration = course.TotalDuration,
            };
        }

        public List<ScheduleResponse> GetSchedulesById(int id)
        {
            var course = _courseRepository.GetById(id);
            if(course == null )
            {
                throw new ArgumentException("enter valid course id to get the schedule");
            }
            return _scheduleService.GetSchedulesByCourseId(id);
        }
    }
}
