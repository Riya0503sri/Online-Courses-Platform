using APIImplementation.Models.Entities;

namespace APIImplementation.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        public Course GetById(int id);
    }
}
