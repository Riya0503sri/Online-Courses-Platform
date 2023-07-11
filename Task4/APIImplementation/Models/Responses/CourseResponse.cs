using System.Collections.Generic;

namespace APIImplementation.Models.Responses
{
    public class CourseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ScheduleResponse> Schedules { get; set; }
        public int TotalDuration { get; set; }
    }
}
