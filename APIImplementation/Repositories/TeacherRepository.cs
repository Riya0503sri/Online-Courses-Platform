using APIImplementation.Models.Entities;
using APIImplementation.Repositories.Interfaces;
using Microsoft.Extensions.Options;

namespace APIImplementation.Repositories
{
    public class TeacherRepository:BaseRepository<Teacher>,ITeacherRepository
    {
        public TeacherRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.OCP)
        {

        }

        public Teacher GetById(int id)
        {
            const string query = @"
select *
from Teachers
where Id=@Id";
            return Get(query, new { Id = id });
        }
    }
}
