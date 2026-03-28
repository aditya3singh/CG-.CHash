using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Repositories
{
    public class StudentRepository : IStudent
    {
        private readonly UniversityContext _context;

        public StudentRepository(UniversityContext context)
        {
            _context = context;
        }

        public bool DeleteStudent(int studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student == null)
            {
                return false;
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Student> GetStudentsByCourseTitle(string courseTitle)
        {
            return _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .Where(s => s.Enrollments.Any(e => e.Course.Title == courseTitle))
                .ToList();
        }
    }
}