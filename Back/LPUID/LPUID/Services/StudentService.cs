using LPUID.Models;
using LPUID.Repositories;
using LPUID.ViewModels;

namespace LPUID.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task RegisterNewStudentAsync(Student student, StudentAdmissionViewModel model)
        {
            // Generate Unique ID Card
            student.IdCard = new IdCard
            {
                UniqueCardNumber = "LPU-" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper(),
                IssueDate = DateTime.UtcNow
            };

            // Auto-allocate Hostel
            student.Hostel = new HostelAllocation
            {
                BlockName = "Block-" + new Random().Next(1, 10),
                RoomNumber = new Random().Next(100, 999).ToString(),
                Floor = new Random().Next(1, 5),
                BedNumber = "B" + new Random().Next(1, 4),
                RoomType = "Double",
                WardenName = "Warden " + new Random().Next(1, 10),
                WardenContact = "+91-98765-" + new Random().Next(10000, 99999)
            };

            // Auto-allocate Mess
            student.MessAllocation = new MessAllocation
            {
                MessName = "Mess-" + new Random().Next(1, 5),
                MealPlan = "All",
                StartDate = DateTime.UtcNow
            };

            // Auto-allocate Transport
            student.TransportAllocation = new TransportAllocation
            {
                RouteNumber = "R-" + new Random().Next(1, 20),
                BusNumber = "LPU-" + new Random().Next(100, 999),
                PickupPoint = "Main Gate",
                DropPoint = "Campus",
                PickupTime = "7:30 AM",
                DropTime = "5:30 PM",
                MonthlyFee = 1500
            };

            await _repository.AddStudentAsync(student);
            await _repository.SaveChangesAsync();
        }

        public double CalculateCGPA(IEnumerable<SemesterMark>? marks)
        {
            if (marks == null || !marks.Any()) return 0;
            return Math.Round(marks.Average(m => m.SGPA), 2);
        }
    }
}
