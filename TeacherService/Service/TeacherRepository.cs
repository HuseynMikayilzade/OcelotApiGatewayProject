using TeacherService.Models;

namespace TeacherService.Service
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly List<Teacher> _teachers;

        public TeacherRepository()
        {
            // İn-memory məlumatlar
            _teachers = new List<Teacher>
            {
                new Teacher { Id = 1, Name = "Cemil", Surname = "Melikzade" },
                new Teacher { Id = 2, Name = "Emil", Surname = "Veliyev" },
            };
        }

        public IEnumerable<Teacher> GetAllTeachers() => _teachers;

        public Teacher GetTeachertById(int id) => _teachers.FirstOrDefault(t => t.Id == id);

        public void AddTeacher(Teacher teacher)
        {
            teacher.Id = _teachers.Max(t => t.Id) + 1;
            _teachers.Add(teacher);
        }
    }
}
