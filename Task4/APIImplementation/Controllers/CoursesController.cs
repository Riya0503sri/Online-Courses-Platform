using APIImplementation.Services.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APIImplementation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet("{id:int}/schedules")]
        public IActionResult GetSchedules([FromRoute] int id)
        {
            try
            {
                var schedules = _courseService.GetSchedulesById(id);
                return Ok(schedules);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
