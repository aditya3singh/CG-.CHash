using EduPortal.Models;

namespace EduPortal.Data
{
    public static class DbSeeder
    {
        public static void SeedData(ApplicationDbContext context)
        {
            // Check if courses already exist
            if (context.Courses.Any())
            {
                return; // Database has been seeded
            }

            // Add sample courses
            var courses = new List<Course>
            {
                new Course { Title = "Computer Science", Credits = 120 },
                new Course { Title = "Business Administration", Credits = 120 },
                new Course { Title = "Engineering", Credits = 130 },
                new Course { Title = "Mathematics", Credits = 120 },
                new Course { Title = "Physics", Credits = 120 },
                new Course { Title = "Chemistry", Credits = 120 },
                new Course { Title = "Biology", Credits = 120 },
                new Course { Title = "Psychology", Credits = 120 }
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();
        }
    }
}
