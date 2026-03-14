using LPUID.Models;
using System.Linq;

namespace LPUID.Data
{
    public static class DbSeeder
    {
        public static void SeedData(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Only seed hostel for students who requested it and don't have one
            var studentsWithoutHostel = context.Students
                .Where(s => s.Hostel == null && s.IsActive)
                .ToList();

            foreach (var student in studentsWithoutHostel)
            {
                // Only add if they don't already have hostel allocation
                if (!context.HostelAllocations.Any(h => h.StudentId == student.Id))
                {
                    context.HostelAllocations.Add(new HostelAllocation
                    {
                        StudentId = student.Id,
                        BlockName = "BH-4",
                        RoomNumber = "420A",
                        Floor = 4,
                        BedNumber = "B1",
                        RoomType = "Double"
                    });
                }
            }

            // DO NOT add random semester marks - let admin add them
            // Students will have 0 CGPA until marks are added by admin

            if (studentsWithoutHostel.Any())
            {
                context.SaveChanges();
            }
        }
    }
}