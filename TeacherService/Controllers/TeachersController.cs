using Microsoft.AspNetCore.Mvc;
using TeacherService.Models;
using TeacherService.Service;

namespace TeacherService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        // GET: api/teacher
        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetAllTeachers()
        {
            var teachers = _teacherRepository.GetAllTeachers();
            return Ok(teachers);
        }

        // GET: api/teacher/{id}
        [HttpGet("{id}")]
        public ActionResult<Teacher> GetTeacherById(int id)
        {
            var teacher = _teacherRepository.GetTeachertById(id);
            if (teacher == null)
                return NotFound($"Teacher with ID {id} not found.");
            return Ok(teacher);
        }

        // POST: api/teacher
        [HttpPost]
        public ActionResult<Teacher> AddTeacher([FromBody] Teacher teacher)
        {
            if (teacher == null || string.IsNullOrWhiteSpace(teacher.Name))
                return BadRequest("Teacher data is invalid.");

            _teacherRepository.AddTeacher(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }
    }
}
