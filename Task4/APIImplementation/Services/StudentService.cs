using APIImplementation.Models.Entities;
using APIImplementation.Models.Requests;
using APIImplementation.Repositories.Interfaces;
using APIImplementation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public int MaxNumberOfCoursesCanBeAttended(List<int> courses, List<string> availableDays)
        {
            List<int> maxClasses = new List<int>();

            foreach (var day in availableDays)
            {
                int maxClassesPerDay = 3;
                Dictionary<int, int> times = new Dictionary<int, int>();
                foreach (var course in courses)
                {
                    var schedules = _courseService.GetSchedulesById(course);
                    var filterSchedules = schedules.FirstOrDefault(s => s.Day == day);
                    if (filterSchedules != null)
                    {
                        var courseStartTime = Get24HourTime(filterSchedules.StartTime);
                        var courseEndTime = Get24HourTime(filterSchedules.EndTime);

                        if (maxClassesPerDay > 0 && times.Count == 0)
                        {
                            maxClassesPerDay--;
                            maxClasses.Add(course);
                            times.Add(courseStartTime, courseEndTime);
                        }
                        else
                        {
                            if (maxClassesPerDay > 0)
                            {
                                foreach (KeyValuePair<int, int> ele in times)
                                {
                                    if (Math.Abs(ele.Value - courseEndTime) > 2)
                                    {
                                        maxClassesPerDay--;
                                        times.Add(courseStartTime, courseEndTime);
                                        maxClasses.Add(course);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return maxClasses.Count;
        }
        private int Get24HourTime(string time)
        {
            int hour = Int32.Parse(time);
            if (time.ToLower().Contains("pm") && hour < 12)
            {
                hour += 12;
            }
            return hour;
        }
    }
}
