using APIImplementation.Models.Entities;

namespace APIImplementation.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        public Teacher GetById(int id);
    }
}
