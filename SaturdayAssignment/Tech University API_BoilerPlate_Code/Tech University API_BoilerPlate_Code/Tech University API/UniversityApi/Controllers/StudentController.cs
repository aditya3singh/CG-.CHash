using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentRepository;

        public StudentController(IStudent studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpDelete("DeleteStudent/{studentId}")]
        public IActionResult DeleteStudent(int studentId)
        {
            var isDeleted = _studentRepository.DeleteStudent(studentId);
            if (isDeleted)
                return Ok("Ok");

            return NotFound("No Records Found");
        }

        [HttpGet("ByCourseTitle/{courseTitle}")]
        public IActionResult GetStudentsByCourseTitle(string courseTitle)
        {
            var students = _studentRepository.GetStudentsByCourseTitle(courseTitle);
            if (students != null && students.Any())
                return Ok(students);

            return NotFound("No Records Found");
        }
    }
}