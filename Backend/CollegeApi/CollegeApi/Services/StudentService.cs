using CollegeApi.DTOs;
using CollegeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly CollegeDbContext _context;

        public StudentService(CollegeDbContext context)
        {
            _context = context;
        }

        // --- NEW: Fetch all students with their rooms ---
        public async Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync()
        {
            var students = await _context.Students
                .Include(s => s.Hostel)
                .ToListAsync();

            return students.Select(s => new StudentResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                HostelRoom = s.Hostel?.RoomNumber
            });
        }

        public async Task<StudentResponseDto> GetStudentAsync(int id)
        {
            var student = await _context.Students
                .Include(s => s.Hostel) // Eager loading the 1-to-1 relation
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null) return null;

            return new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                HostelRoom = student.Hostel?.RoomNumber
            };
        }

        public async Task<StudentResponseDto> AddStudentWithHostelAsync(CreateStudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Hostel = new Hostel
                {
                    RoomNumber = dto.RoomNumber
                }
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return await GetStudentAsync(student.Id);
        }

        public async Task<bool> UpdateStudentAsync(int id, UpdateStudentDto dto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            student.Name = dto.Name;
            student.Email = dto.Email;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateHostelRoomAsync(int studentId, UpdateHostelDto dto)
        {
            var hostel = await _context.Hostels.FirstOrDefaultAsync(h => h.StudentId == studentId);
            if (hostel == null) return false;

            hostel.RoomNumber = dto.RoomNumber;

            _context.Hostels.Update(hostel);
            await _context.SaveChangesAsync();
            return true;
        }

        // --- NEW: Remove the hostel room without deleting the student ---
        public async Task<bool> RemoveHostelRoomAsync(int studentId)
        {
            var hostel = await _context.Hostels.FirstOrDefaultAsync(h => h.StudentId == studentId);
            if (hostel == null) return false;

            _context.Hostels.Remove(hostel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}