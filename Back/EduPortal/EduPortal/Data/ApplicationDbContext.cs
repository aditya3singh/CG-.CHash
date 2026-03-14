using Microsoft.EntityFrameworkCore;
using EduPortal.Models;

namespace EduPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}