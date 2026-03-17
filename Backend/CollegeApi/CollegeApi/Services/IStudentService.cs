using CollegeApi.DTOs;

namespace CollegeApi.Services
{
    public interface IStudentService
    {
        // Added GetAllStudentsAsync
        Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync();
        Task<StudentResponseDto> GetStudentAsync(int id);
        Task<StudentResponseDto> AddStudentWithHostelAsync(CreateStudentDto dto);
        Task<bool> UpdateStudentAsync(int id, UpdateStudentDto dto);
        Task<bool> UpdateHostelRoomAsync(int studentId, UpdateHostelDto dto);

        // Added RemoveHostelRoomAsync
        Task<bool> RemoveHostelRoomAsync(int studentId);
        Task<bool> DeleteStudentAsync(int id);
    }
}