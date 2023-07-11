using APIImplementation.Models.Entities;

namespace APIImplementation.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        /*public int Add(Student student, int courseId, int scheduleId);*/
        int AddStudent(Student student, int courseId, int scheduleId);
    }
}
