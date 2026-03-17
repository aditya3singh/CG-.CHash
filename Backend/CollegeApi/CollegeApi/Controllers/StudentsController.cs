using CollegeApi.DTOs;
using CollegeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // --- NEW: Get all students ---
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentService.GetStudentAsync(id);
            if (student == null) return NotFound("Student not found.");
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] CreateStudentDto dto)
        {
            var newStudent = await _studentService.AddStudentWithHostelAsync(dto);
            return CreatedAtAction(nameof(GetStudent), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentDto dto)
        {
            var updated = await _studentService.UpdateStudentAsync(id, dto);
            if (!updated) return NotFound("Student not found.");
            return NoContent();
        }

        [HttpPatch("{id}/hostel")]
        public async Task<IActionResult> UpdateHostelRoom(int id, [FromBody] UpdateHostelDto dto)
        {
            var updated = await _studentService.UpdateHostelRoomAsync(id, dto);
            if (!updated) return NotFound("Hostel room not found for this student.");
            return NoContent();
        }

        // --- NEW: Remove a student from the hostel only ---
        [HttpDelete("{id}/hostel")]
        public async Task<IActionResult> RemoveFromHostel(int id)
        {
            var removed = await _studentService.RemoveHostelRoomAsync(id);
            if (!removed) return NotFound("Student does not have an assigned hostel room.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentService.DeleteStudentAsync(id);
            if (!deleted) return NotFound("Student not found.");
            return NoContent();
        }
    }
}