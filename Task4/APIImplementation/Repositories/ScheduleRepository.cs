using APIImplementation.Models.Entities;
using APIImplementation.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Collections.Generic;

namespace APIImplementation.Repositories
{
    public class ScheduleRepository:BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.OCP)
        {

        }
        public IEnumerable<Schedule> GetSchedulesByCourseId(int id)
        {
            const string query = @"
select *
from Schedules
where CourseId=@CourseId";
            return GetAll(query, new { CourseId = id });
        } 
    }
}
