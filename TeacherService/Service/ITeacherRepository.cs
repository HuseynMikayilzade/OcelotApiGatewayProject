using TeacherService.Models;

namespace TeacherService.Service
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeachertById(int id);
        void AddTeacher(Teacher teacher);
    }
}
