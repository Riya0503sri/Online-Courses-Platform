using APIImplementation.Models.Responses;
using APIImplementation.Repositories.Interfaces;
using APIImplementation.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace APIImplementation.Services
{
    public class ScheduleService:IScheduleService
    {
        private readonly ITeacherService _teacherService;
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleService(ITeacherService teacherService, IScheduleRepository scheduleRepository)
        {
            _teacherService = teacherService;
            _scheduleRepository = scheduleRepository;
        }

        public List<ScheduleResponse> GetSchedulesByCourseId(int id)
        {
            var schedules=_scheduleRepository.GetSchedulesByCourseId(id);
            if (schedules == null)
            {
                return null;
            }
            var result = schedules.Select(s => new ScheduleResponse
            {
                Id = s.Id,
                Teacher = _teacherService.GetById(s.TeacherId),
                Day = s.Day,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
            });
            return result.ToList();
        }
    }
}
