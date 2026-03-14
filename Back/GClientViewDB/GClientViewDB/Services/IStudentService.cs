using GClientViewDB.Models;

namespace GClientViewDB.Services;

public interface IStudentService
{
    Task<List<Student>> GetAllStudentsAsync();
    Task<Student?> GetStudentByIdAsync(int id);
    Task AddStudentAsync(Student student);
    Task UpdateStudentAsync(Student student);
    Task<bool> DeleteStudentAsync(int id);
    Task<bool> StudentExistsAsync(int id);
    Task<List<Student>> SearchByNameAsync(string name);
    Task<List<Student>> SearchByEmailAsync(string email);
    Task<List<Student>> SearchByStatusAsync(string status);
    Task<List<Student>> SearchAsync(string? name, string? email, string? status);
}
