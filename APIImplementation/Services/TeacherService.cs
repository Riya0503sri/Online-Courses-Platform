using APIImplementation.Models.Responses;
using APIImplementation.Repositories.Interfaces;
using APIImplementation.Services.Interfaces;
using System;

namespace APIImplementation.Services
{
    public class TeacherService :ITeacherService
    {
        private readonly ITeacherRepository _teacherRespository;
        public TeacherService(ITeacherRepository teacherRespository)
        {
            _teacherRespository = teacherRespository;
        }

        public TeacherResponse GetById(int id)
        {
            var teacher=_teacherRespository.GetById(id);
            if(teacher==null)
            {
                throw new ArgumentException("Enter valid teacherId"); 
            }
            return new TeacherResponse
            {
                Id = id,
                Name = teacher.Name
            };
        }
    }
}
