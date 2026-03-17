using StudentRelation.DTOs;

namespace StudentRelation.Services;

public interface IHostelService
{
    Task<HostelDto?> GetHostelByStudentIdAsync(int studentId);
    Task<HostelDto?> UpdateHostelAsync(int studentId, UpdateHostelDto updateDto);
    Task<bool> DeleteHostelAsync(int studentId);
    Task<IEnumerable<HostelDto>> GetAllHostelsAsync();
}
