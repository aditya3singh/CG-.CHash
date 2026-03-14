using LPUID.Models;

namespace LPUID.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Student student);
        Task SaveChangesAsync();

        Task<IEnumerable<Student>> GetAllStudentsAsync();
    }
}
