using LPUID.Models;
using LPUID.ViewModels;

namespace LPUID.Services
{
    public interface IStudentService
    {
        Task RegisterNewStudentAsync(Student student, StudentAdmissionViewModel model);
        double CalculateCGPA(IEnumerable<SemesterMark>? marks);
    }
}
