using APIImplementation.Models.Requests;
using APIImplementation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APIImplementation.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] StudentRequest studentRequest)
        {
            int id;
            try
            {
                id = _studentService.Add(studentRequest);
                return Created("~/students", new { id });
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
