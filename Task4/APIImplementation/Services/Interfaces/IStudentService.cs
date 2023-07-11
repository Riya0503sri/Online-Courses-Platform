using APIImplementation.Models.Requests;
using System.Collections.Generic;

namespace APIImplementation.Services.Interfaces
{
    public interface IStudentService
    {
        public int Add(StudentRequest student);

        public int MaxNumberOfCoursesCanBeAttended(List<int> courses, List<string> availableDays);
    }
}
