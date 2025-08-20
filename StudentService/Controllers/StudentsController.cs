using Microsoft.AspNetCore.Mvc;
using StudentService.Models;
using StudentService.Services;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        // GET: api/student
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(_repository.GetAllStudents());
        }

        // GET: api/student/1
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        // POST: api/student
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            _repository.AddStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }
    }
}
