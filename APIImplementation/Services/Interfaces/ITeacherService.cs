using APIImplementation.Models.Responses;

namespace APIImplementation.Services.Interfaces
{
    public interface ITeacherService
    {
        public TeacherResponse GetById(int id);
    }
}
