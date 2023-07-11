using APIImplementation.Models.Entities;
using System.Collections.Generic;

namespace APIImplementation.Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        public IEnumerable<Schedule> GetSchedulesByCourseId(int id);
    }
}
