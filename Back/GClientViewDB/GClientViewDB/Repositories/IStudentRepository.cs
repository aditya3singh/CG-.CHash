using GClientViewDB.Models;

namespace GClientViewDB.Repositories;

public interface IStudentRepository
{
    Task<List<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(int id);
    Task<Student> AddAsync(Student student);
    Task<Student> UpdateAsync(Student student);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<List<Student>> SearchByNameAsync(string name);
    Task<List<Student>> SearchByEmailAsync(string email);
    Task<List<Student>> SearchByStatusAsync(string status);
    Task<List<Student>> SearchAsync(string? name, string? email, string? status);
}
