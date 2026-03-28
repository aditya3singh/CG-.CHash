using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Repositories
{
    public class CourseRepository : ICourse
    {
        private readonly UniversityContext _context;

        public CourseRepository(UniversityContext context)
        {
            _context = context;
        }

        public bool AddCourse(Course course)
        {
            var existing = _context.Courses.Find(course.CourseId);
            if (existing != null) return false;
            _context.Courses.Add(course);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateCourse(Course course)
        {
            var existingCourse = _context.Courses.Find(course.CourseId);
            if (existingCourse == null)
            {
                return false;
            }

            existingCourse.Title = course.Title;
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Course> GetCoursesWithEnrollmentsAboveGrade(int grade)
        {
            return _context.Courses
                .Include(c => c.Enrollments)
                .Where(c => c.Enrollments.Any(e => e.Grade > grade))
                .ToList();
        }

        public IEnumerable<Course> GetCoursesByInstructorName(string instructorName)
        {
            return _context.Courses
                .Include(c => c.InstructorCourses)
                    .ThenInclude(ic => ic.Instructor)
                .Where(c => c.InstructorCourses.Any(ic => ic.Instructor.Name == instructorName))
                .ToList();
        }
    }
}