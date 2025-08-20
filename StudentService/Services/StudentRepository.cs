using StudentService.Models;

namespace StudentService.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> _students;

        public StudentRepository()
        {
            // İn-memory məlumatlar
            _students = new List<Student>
            {
                new Student { Id = 1, Name = "Cavid", Surname = "Sirinov" },
                new Student { Id = 2, Name = "Sara Khan", Surname = "Mehdizade" },
               
            };
        }

        public IEnumerable<Student> GetAllStudents() => _students;

        public Student GetStudentById(int id) => _students.FirstOrDefault(s => s.Id == id);

        public void AddStudent(Student student)
        {
            student.Id = _students.Max(s => s.Id) + 1;
            _students.Add(student);
        }
    }
}
