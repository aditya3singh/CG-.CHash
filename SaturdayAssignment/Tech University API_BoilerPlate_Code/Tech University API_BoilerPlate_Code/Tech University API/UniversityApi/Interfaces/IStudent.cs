using UniversityApi.Models;

namespace UniversityApi.Interfaces
{
    public interface IStudent
    {
        bool DeleteStudent(int studentId);
        IEnumerable<Student> GetStudentsByCourseTitle(string courseTitle);
    }
}