using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Repositories
{
    public class InstructorRepository : IInstructor
    {
        private readonly UniversityContext _context;

        public InstructorRepository(UniversityContext context)
        {
            _context = context;
        }

        public bool AddInstructor(Instructor instructor)
        {
            var existingInstructor = _context.Instructors.Find(instructor.InstructorId);
            if (existingInstructor != null)
            {
                return false;
            }

            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Instructor> GetInstructorsWithCourseCountAbove(int count)
        {
            return _context.Instructors
                .Include(i => i.InstructorCourses)
                .Where(i => i.InstructorCourses.Count() > count)
                .ToList();
        }

        public IEnumerable<Instructor> GetInstructorsWithMostEnrollments()
        {
            var instructorsWithCounts = _context.Instructors
                .Include(i => i.InstructorCourses)
                    .ThenInclude(ic => ic.Course)
                        .ThenInclude(c => c.Enrollments)
                .Select(i => new
                {
                    Instructor = i,
                    EnrollmentCount = i.InstructorCourses.SelectMany(ic => ic.Course.Enrollments).Count()
                }).ToList();

            if (!instructorsWithCounts.Any())
            {
                return new List<Instructor>();
            }

            var maxEnrollments = instructorsWithCounts.Max(x => x.EnrollmentCount);

            return instructorsWithCounts
                .Where(x => x.EnrollmentCount == maxEnrollments)
                .Select(x => x.Instructor)
                .ToList();
        }
    }
}