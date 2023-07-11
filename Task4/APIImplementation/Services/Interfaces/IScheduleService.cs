using APIImplementation.Models.Responses;
using System.Collections.Generic;

namespace APIImplementation.Services.Interfaces
{
    public interface IScheduleService
    {
        public List<ScheduleResponse> GetSchedulesByCourseId(int id);
    }
}
