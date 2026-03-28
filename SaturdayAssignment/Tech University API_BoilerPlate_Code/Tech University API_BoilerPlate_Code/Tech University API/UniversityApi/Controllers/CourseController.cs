using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _courseRepository;

        public CourseController(ICourse courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost("AddCourse")]
        public IActionResult AddCourse([FromBody] Course course)
        {
            var isAdded = _courseRepository.AddCourse(course);
            if (isAdded) return Ok("Ok");
            return BadRequest("BadRequest");
        }

        [HttpPut("UpdateCourse")]
        public IActionResult UpdateCourse([FromBody] Course course)
        {
            var isUpdated = _courseRepository.UpdateCourse(course);
            if (isUpdated)
                return Ok("Ok");
            
            return BadRequest("BadRequest");
        }

        [HttpGet("WithEnrollmentsAboveGrade/{grade}")]
        public IActionResult GetCoursesWithEnrollmentsAboveGrade(int grade)
        {
            var courses = _courseRepository.GetCoursesWithEnrollmentsAboveGrade(grade);
            if (courses != null && courses.Any())
                return Ok(courses);

            return NotFound("No Records Found");
        }

        [HttpGet("ByInstructorName/{instructorName}")]
        public IActionResult GetCoursesByInstructorName(string instructorName)
        {
            var courses = _courseRepository.GetCoursesByInstructorName(instructorName);
            if (courses != null && courses.Any())
                return Ok(courses);

            return NotFound("No Records Found");
        }
    }
}