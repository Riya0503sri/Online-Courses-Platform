namespace APIImplementation.Models.Requests
{
    public class StudentRequest
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
        public int ScheduleId { get; set; }
    }
}
