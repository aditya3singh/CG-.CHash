using UniversityApi.Models;

namespace UniversityApi.Interfaces
{
    public interface IInstructor
    {
        bool AddInstructor(Instructor instructor);
        IEnumerable<Instructor> GetInstructorsWithCourseCountAbove(int count);
        IEnumerable<Instructor> GetInstructorsWithMostEnrollments();
    }
}