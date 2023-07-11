using APIImplementation.Models.Requests;

namespace APIImplementation.Services.Interfaces
{
    public interface IStudentService
    {
        public int Add(StudentRequest student);
    }
}
