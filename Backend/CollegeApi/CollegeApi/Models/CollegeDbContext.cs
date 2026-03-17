using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CollegeApi.Models;

public partial class CollegeDbContext : DbContext
{
    public CollegeDbContext()
    {
    }

    public CollegeDbContext(DbContextOptions<CollegeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hostel> Hostels { get; set; }

    public virtual DbSet<Student> Students { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hostel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hostels__3214EC07EB0A4D64");

            entity.HasIndex(e => e.StudentId, "UQ__Hostels__32C52B98DA04F075").IsUnique();

            entity.Property(e => e.RoomNumber).HasMaxLength(50);

            entity.HasOne(d => d.Student).WithOne(p => p.Hostel)
                .HasForeignKey<Hostel>(d => d.StudentId)
                .HasConstraintName("FK_Hostel_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07A0B762CC");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
