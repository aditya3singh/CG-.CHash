using Microsoft.EntityFrameworkCore;
using StudentRelation.Data;
using StudentRelation.DTOs;

namespace StudentRelation.Services;

public class HostelService : IHostelService
{
    private readonly AppDbContext _context;

    public HostelService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HostelDto>> GetAllHostelsAsync()
    {
        var hostels = await _context.Hostels.ToListAsync();
        return hostels.Select(h => new HostelDto
        {
            Id = h.Id,
            RoomNumber = h.RoomNumber,
            BlockName = h.BlockName,
            StudentId = h.StudentId
        });
    }

    public async Task<HostelDto?> GetHostelByStudentIdAsync(int studentId)
    {
        var hostel = await _context.Hostels
            .FirstOrDefaultAsync(h => h.StudentId == studentId);

        if (hostel == null) return null;

        return new HostelDto
        {
            Id = hostel.Id,
            RoomNumber = hostel.RoomNumber,
            BlockName = hostel.BlockName,
            StudentId = hostel.StudentId
        };
    }

    public async Task<HostelDto?> UpdateHostelAsync(int studentId, UpdateHostelDto updateDto)
    {
        var hostel = await _context.Hostels
            .FirstOrDefaultAsync(h => h.StudentId == studentId);

        if (hostel == null)
        {
            throw new InvalidOperationException("Student does not have a hostel assigned.");
        }

        // Check if the new room is already occupied (excluding current hostel)
        if (await _context.Hostels.AnyAsync(h => 
            h.Id != hostel.Id && 
            h.RoomNumber == updateDto.RoomNumber && 
            h.BlockName == updateDto.BlockName))
        {
            throw new InvalidOperationException("This room is already occupied.");
        }

        hostel.RoomNumber = updateDto.RoomNumber;
        hostel.BlockName = updateDto.BlockName;

        await _context.SaveChangesAsync();

        return new HostelDto
        {
            Id = hostel.Id,
            RoomNumber = hostel.RoomNumber,
            BlockName = hostel.BlockName,
            StudentId = hostel.StudentId
        };
    }

    public async Task<bool> DeleteHostelAsync(int studentId)
    {
        var hostel = await _context.Hostels
            .FirstOrDefaultAsync(h => h.StudentId == studentId);

        if (hostel == null) return false;

        _context.Hostels.Remove(hostel);
        await _context.SaveChangesAsync();
        return true;
    }
}
