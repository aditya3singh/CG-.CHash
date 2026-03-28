using UniversityApi.Models;

namespace UniversityApi.Interfaces
{
    public interface ICourse
    {
        bool AddCourse(Course course);
        bool UpdateCourse(Course course);
        IEnumerable<Course> GetCoursesWithEnrollmentsAboveGrade(int grade);
        IEnumerable<Course> GetCoursesByInstructorName(string instructorName);
    }
}