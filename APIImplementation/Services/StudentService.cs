using APIImplementation.Models.Entities;
using APIImplementation.Models.Requests;
using APIImplementation.Repositories.Interfaces;
using APIImplementation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace APIImplementation.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseService _courseService;
        private readonly IScheduleService _scheduleService;

        public StudentService(IStudentRepository studentRepository, ICourseService courseService, IScheduleService scheduleService)
        {
            _studentRepository = studentRepository;
            _courseService = courseService;
            _scheduleService = scheduleService;
        }

        public int Add(StudentRequest studentRequest)
        {
            Validate(studentRequest.Name, studentRequest.CourseId, studentRequest.ScheduleId);
            var newStudent = new Student()
            {
                Name = studentRequest.Name,

            };
            return _studentRepository.AddStudent(newStudent,studentRequest.CourseId,studentRequest.ScheduleId);
        }
        public void Validate(string name,int courseId, int scheduleId)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Enter student name");
            }
            var course = _courseService.GetById(courseId);
            if(course == null)
            {
                throw new ArgumentException("enter valid courseID");
            }
            var schedules = _courseService.GetSchedulesById(course.Id);
            var schedule = schedules.SingleOrDefault(x => x.Id == scheduleId);
            if (schedule == null)
            {
                throw new ArgumentException("enter valid schedule id");
            }

        }
    }
}
