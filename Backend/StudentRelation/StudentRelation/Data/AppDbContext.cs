using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentRelation.Models;

namespace StudentRelation.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Hostel> Hostels => Set<Hostel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Crucial for Identity tables!

        // Configure the 1:1 Relationship
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Hostel)
            .WithOne(h => h.Student)
            .HasForeignKey<Hostel>(h => h.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        // Cascade means: Delete Student -> Hostel record is deleted automatically.
    }
}