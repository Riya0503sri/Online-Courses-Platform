using APIImplementation.Models.Entities;
using APIImplementation.Repositories.Interfaces;
using APIImplementation.Services.Interfaces;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;

namespace APIImplementation.Repositories
{
    public class StudentRepository : BaseRepository<Student>,IStudentRepository
    {
        private readonly string _connectionString;
        public StudentRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.OCP)
        {
            _connectionString = connectionString.Value.OCP;
        }
        public int AddStudent(Student student, int courseId, int scheduleId)
        {
            using var connection = new SqlConnection(_connectionString);
            const string procedure = "usp_insert_course_student_registration";

            var parameters = new DynamicParameters();
            parameters.Add("@Name", student.Name, DbType.String);
            parameters.Add("@CourseId", courseId, DbType.Int64);
            parameters.Add("@ScheduleId", scheduleId, DbType.Int32);
            parameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            connection.Query(procedure, parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("@Id");
        }
        
        
    }
}
