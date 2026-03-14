using LPUID.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LPUID.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<HostelAllocation> HostelAllocations { get; set; }
        public DbSet<SemesterMark> SemesterMarks { get; set; }
        public DbSet<IdCard> IdCards { get; set; }
        public DbSet<MessAllocation> MessAllocations { get; set; }
        public DbSet<TransportAllocation> TransportAllocations { get; set; }
        public DbSet<HostelLeave> HostelLeaves { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Required for Identity (Authentication)

            // Fluent API: Enforcing Uniqueness
            modelBuilder.Entity<Student>().HasIndex(s => s.ApplicationNumber).IsUnique();
            modelBuilder.Entity<Student>().HasIndex(s => s.Email).IsUnique();
            modelBuilder.Entity<IdCard>().HasIndex(i => i.UniqueCardNumber).IsUnique();

            // Fluent API: Defining 1-to-1 Relationships
            modelBuilder.Entity<Student>()
                .HasOne(s => s.IdCard)
                .WithOne(i => i.Student)
                .HasForeignKey<IdCard>(i => i.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Hostel)
                .WithOne(h => h.Student)
                .HasForeignKey<HostelAllocation>(h => h.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.MessAllocation)
                .WithOne(m => m.Student)
                .HasForeignKey<MessAllocation>(m => m.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.TransportAllocation)
                .WithOne(t => t.Student)
                .HasForeignKey<TransportAllocation>(t => t.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Fluent API: Defining 1-to-Many Relationships
            modelBuilder.Entity<Student>()
                .HasMany(s => s.HostelLeaves)
                .WithOne(hl => hl.Student)
                .HasForeignKey(hl => hl.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.ClassSchedules)
                .WithOne(cs => cs.Student)
                .HasForeignKey(cs => cs.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}