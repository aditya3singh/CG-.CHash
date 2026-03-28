using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructor _instructorRepository;

        public InstructorController(IInstructor instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        [HttpPost("AddInstructor")]
        public IActionResult AddInstructor([FromBody] Instructor instructor)
        {
            var isAdded = _instructorRepository.AddInstructor(instructor);
            if (isAdded)
                return Ok("Ok");

            return BadRequest("BadRequest");
        }

        [HttpGet("WithCourseCountAbove/{count}")]
        public IActionResult GetInstructorsWithCourseCountAbove(int count)
        {
            var instructors = _instructorRepository.GetInstructorsWithCourseCountAbove(count);
            if (instructors != null && instructors.Any())
                return Ok(instructors);

            return NotFound("No Records Found");
        }

        [HttpGet("WithMostEnrollments")]
        public IActionResult GetInstructorsWithMostEnrollments()
        {
            var instructors = _instructorRepository.GetInstructorsWithMostEnrollments();
            if (instructors != null && instructors.Any())
                return Ok(instructors);

            return NotFound("No Records Found");
        }
    }
}