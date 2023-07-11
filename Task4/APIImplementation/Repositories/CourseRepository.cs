using APIImplementation.Models.Entities;
using APIImplementation.Repositories.Interfaces;
using Microsoft.Extensions.Options;

namespace APIImplementation.Repositories
{
    public class CourseRepository : BaseRepository<Course>,ICourseRepository
    {
        public CourseRepository(IOptions<ConnectionString> connectionString)
            :base(connectionString.Value.OCP)
        {

        }

        public Course GetById(int id)
        {
            const string query = @"
SELECT *
FROM COURSES
WHERE Id=@Id";
            return Get(query, new { Id = id });
        }
    }
}
