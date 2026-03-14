using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.DTOs;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        // In-memory list to store students temporarily while the app runs
        private static readonly List<Student> _students = new List<Student>();
        private static readonly Random _random = new Random();

        // 1. POST: Create the student (Id, Name, Age)
        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentCreateDto dto)
        {
            // Check if student with the same ID already exists
            if (_students.Any(s => s.Id == dto.Id))
            {
                return BadRequest("A student with this ID already exists.");
            }

            // Map DTO to Model
            var student = new Student
            {
                Id = dto.Id,
                Name = dto.Name,
                Age = dto.Age
            };

            _students.Add(student);
            return Ok(new { Message = "Student created successfully!" });
        }

        // 2. PUT: Update student marks (Id, M1, M2)
        [HttpPut("{id}")]
        public IActionResult UpdateMarks(int id, [FromBody] StudentUpdateDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("The ID in the URL must match the ID in the body.");
            }

            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            // Update the internal model
            student.M1 = dto.M1;
            student.M2 = dto.M2;

            return Ok(new { Message = "Student marks updated successfully!" });
        }

        // 3. GET: Get result by Id (Id, Name, M1, M2, Total, Grade)
        [HttpGet("{id}")]
        public IActionResult GetResultById(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            // Calculate total
            int total = student.M1 + student.M2;

            // Generate a random grade as requested
            string[] grades = { "A+", "A", "B", "C", "D", "F" };
            string randomGrade = grades[_random.Next(grades.Length)];

            // Map Model to Result DTO
            var resultDto = new StudentResultDto
            {
                Id = student.Id,
                Name = student.Name,
                M1 = student.M1,
                M2 = student.M2,
                Total = total,
                Grade = randomGrade
            };

            return Ok(resultDto);
        }
    }
}