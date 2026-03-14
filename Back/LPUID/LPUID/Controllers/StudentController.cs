using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LPUID.Models;
using LPUID.Services;
using LPUID.Repositories;
using LPUID.ViewModels;
using LPUID.Data;
using Microsoft.EntityFrameworkCore;

namespace LPUID.Controllers
{
    [Authorize]
    [Route("Portal/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public StudentController(
            IStudentService studentService, 
            IStudentRepository studentRepository,
            ApplicationDbContext context,
            IWebHostEnvironment environment)
        {
            _studentService = studentService;
            _studentRepository = studentRepository;
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return View(students);
        }

        [HttpGet("Admission")]
        public IActionResult Admission()
        {
            return View(new StudentAdmissionViewModel());
        }

        [HttpPost("Admission")]
        public async Task<IActionResult> Admission(StudentAdmissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                string? profilePicturePath = null;
                if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "profiles");
                    Directory.CreateDirectory(uploadsFolder);
                    
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ProfilePicture.CopyToAsync(fileStream);
                    }
                    
                    profilePicturePath = "/uploads/profiles/" + uniqueFileName;
                }

                var student = new Student
                {
                    ApplicationNumber = model.ApplicationNumber,
                    FullName = model.FullName,
                    Email = model.Email,
                    Course = model.Course,
                    PhoneNumber = model.PhoneNumber,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    Address = model.Address,
                    ProfilePicturePath = profilePicturePath
                };

                await _studentService.RegisterNewStudentAsync(student, model);
                return RedirectToAction("Dashboard", new { id = student.Id });
            }
            return View(model);
        }

        [HttpGet("{id}/Dashboard")]
        public async Task<IActionResult> Dashboard(int id)
        {
            var student = await _context.Students
                .Include(s => s.IdCard)
                .Include(s => s.Hostel)
                .Include(s => s.MessAllocation)
                .Include(s => s.TransportAllocation)
                .Include(s => s.SemesterMarks)
                .Include(s => s.HostelLeaves)
                .Include(s => s.ClassSchedules)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null) return NotFound();

            ViewBag.CGPA = _studentService.CalculateCGPA(student.SemesterMarks);
            return View(student);
        }

        [HttpGet("{id}/IdCard")]
        public async Task<IActionResult> IdCard(int id)
        {
            var student = await _context.Students
                .Include(s => s.IdCard)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null) return NotFound();
            return View(student);
        }

        [HttpGet("{id}/ApplyLeave")]
        public IActionResult ApplyLeave(int id)
        {
            ViewBag.StudentId = id;
            return View(new HostelLeave { StudentId = id });
        }

        [HttpPost("{id}/ApplyLeave")]
        public async Task<IActionResult> ApplyLeave(HostelLeave leave)
        {
            if (ModelState.IsValid)
            {
                _context.HostelLeaves.Add(leave);
                await _context.SaveChangesAsync();
                return RedirectToAction("Dashboard", new { id = leave.StudentId });
            }
            return View(leave);
        }

        [HttpGet("{id}/Schedule")]
        public async Task<IActionResult> Schedule(int id)
        {
            var schedules = await _context.ClassSchedules
                .Where(cs => cs.StudentId == id && cs.IsActive)
                .OrderBy(cs => cs.DayOfWeek)
                .ThenBy(cs => cs.StartTime)
                .ToListAsync();

            ViewBag.StudentId = id;
            return View(schedules);
        }

        [HttpGet("{id}/ChangePicture")]
        public async Task<IActionResult> ChangePicture(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost("{id}/ChangePicture")]
        public async Task<IActionResult> ChangePicture(int id, IFormFile newPicture)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            if (newPicture != null && newPicture.Length > 0)
            {
                // Delete old picture if exists
                if (!string.IsNullOrEmpty(student.ProfilePicturePath))
                {
                    var oldFilePath = Path.Combine(_environment.WebRootPath, student.ProfilePicturePath.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                // Save new picture
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "profiles");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + newPicture.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newPicture.CopyToAsync(fileStream);
                }

                student.ProfilePicturePath = "/uploads/profiles/" + uniqueFileName;
                _context.Students.Update(student);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Profile picture updated successfully!";
            }

            return RedirectToAction("Dashboard", new { id = student.Id });
        }
    }
}
