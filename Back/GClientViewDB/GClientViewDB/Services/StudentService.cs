using GClientViewDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GClientViewDB.Services;

public class StudentService : IStudentService
{
    private readonly StudentPortalDbContext _context;

    public StudentService(StudentPortalDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);
    }

    public async Task AddStudentAsync(Student student)
    {
        student.CreatedAt = DateTime.Now;
        if (string.IsNullOrEmpty(student.Status))
        {
            student.Status = "Active";
        }
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStudentAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var student = await _context.Students
            .Include(s => s.Enrollments)
            .FirstOrDefaultAsync(s => s.StudentId == id);
        if (student == null) return false;

        _context.Enrollments.RemoveRange(student.Enrollments);
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> StudentExistsAsync(int id)
    {
        return await _context.Students.AnyAsync(s => s.StudentId == id);
    }

    public async Task<List<Student>> SearchByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return await _context.Students.ToListAsync();

        return await _context.Students
            .Where(s => s.FullName.Contains(name))
            .ToListAsync();
    }

    public async Task<List<Student>> SearchByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return await _context.Students.ToListAsync();

        return await _context.Students
            .Where(s => s.Email.Contains(email))
            .ToListAsync();
    }

    public async Task<List<Student>> SearchByStatusAsync(string status)
    {
        if (string.IsNullOrWhiteSpace(status))
            return await _context.Students.ToListAsync();

        return await _context.Students
            .Where(s => s.Status == status)
            .ToListAsync();
    }

    public async Task<List<Student>> SearchAsync(string? name, string? email, string? status)
    {
        var query = _context.Students.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(s => s.FullName.Contains(name));

        if (!string.IsNullOrWhiteSpace(email))
            query = query.Where(s => s.Email.Contains(email));

        if (!string.IsNullOrWhiteSpace(status))
            query = query.Where(s => s.Status == status);

        return await query.ToListAsync();
    }
}
