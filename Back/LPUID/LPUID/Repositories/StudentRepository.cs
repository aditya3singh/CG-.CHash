using LPUID.Data;
using LPUID.Models;
using Microsoft.EntityFrameworkCore;
namespace LPUID.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.IdCard)
                .Include(s => s.Hostel)
                .ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.SemesterMarks)
                .Include(s => s.Hostel)
                .Include(s => s.IdCard)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddStudentAsync(Student student) => await _context.Students.AddAsync(student);
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
