namespace APIImplementation.Models.Responses
{
    public class ScheduleResponse
    {
        public int Id { get; set; }
        public TeacherResponse Teacher { get; set; }
        public string Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
