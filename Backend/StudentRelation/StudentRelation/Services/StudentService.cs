using Microsoft.EntityFrameworkCore;
using StudentRelation.Data;
using StudentRelation.DTOs;
using StudentRelation.Models;

namespace StudentRelation.Services;

public class StudentService : IStudentService
{
    private readonly AppDbContext _context;

    public StudentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
    {
        var students = await _context.Students
            .Include(s => s.Hostel)
            .ToListAsync();

        return students.Select(MapToDto);
    }

    public async Task<StudentDto?> GetStudentByIdAsync(int id)
    {
        var student = await _context.Students
            .Include(s => s.Hostel)
            .FirstOrDefaultAsync(s => s.Id == id);

        return student == null ? null : MapToDto(student);
    }

    public async Task<StudentDto> CreateStudentAsync(CreateStudentDto createDto)
    {
        // Check if email already exists
        if (await _context.Students.AnyAsync(s => s.Email == createDto.Email))
        {
            throw new InvalidOperationException("A student with this email already exists.");
        }

        var student = new Student
        {
            Name = createDto.Name,
            Email = createDto.Email,
            CollegeName = createDto.CollegeName
        };

        // If hostel information is provided, create hostel record
        if (createDto.Hostel != null)
        {
            // Check if room is already occupied
            if (await _context.Hostels.AnyAsync(h => 
                h.RoomNumber == createDto.Hostel.RoomNumber && 
                h.BlockName == createDto.Hostel.BlockName))
            {
                throw new InvalidOperationException("This room is already occupied.");
            }

            student.Hostel = new Hostel
            {
                RoomNumber = createDto.Hostel.RoomNumber,
                BlockName = createDto.Hostel.BlockName
            };
        }

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return MapToDto(student);
    }

    public async Task<StudentDto?> UpdateStudentAsync(int id, UpdateStudentDto updateDto)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return null;

        // Check if email is being changed and if it already exists
        if (student.Email != updateDto.Email && 
            await _context.Students.AnyAsync(s => s.Email == updateDto.Email))
        {
            throw new InvalidOperationException("A student with this email already exists.");
        }

        student.Name = updateDto.Name;
        student.Email = updateDto.Email;
        student.CollegeName = updateDto.CollegeName;

        await _context.SaveChangesAsync();

        return await GetStudentByIdAsync(id);
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return false;

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return true;
    }

    private static StudentDto MapToDto(Student student)
    {
        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            CollegeName = student.CollegeName,
            Hostel = student.Hostel == null ? null : new HostelDto
            {
                Id = student.Hostel.Id,
                RoomNumber = student.Hostel.RoomNumber,
                BlockName = student.Hostel.BlockName,
                StudentId = student.Hostel.StudentId
            }
        };
    }
}
