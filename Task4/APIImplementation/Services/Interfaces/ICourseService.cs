using APIImplementation.Models.Responses;
using System.Collections.Generic;

namespace APIImplementation.Services.Interfaces
{
    public interface ICourseService
    {
        public List<ScheduleResponse> GetSchedulesById(int id);
        public CourseResponse GetById(int id);
    }
}
