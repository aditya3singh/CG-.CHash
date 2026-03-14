using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using LPUID.Data;
using LPUID.Models;

namespace LPUID.Controllers
{
    [Authorize]
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Admin Dashboard
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stats = new
            {
                TotalStudents = await _context.Students.CountAsync(),
                ActiveStudents = await _context.Students.CountAsync(s => s.IsActive),
                TotalHostelAllocations = await _context.HostelAllocations.CountAsync(),
                PendingLeaves = await _context.HostelLeaves.CountAsync(hl => hl.Status == "Pending")
            };
            
            ViewBag.Stats = stats;
            return View();
        }

        // Students Management
        [HttpGet("Students")]
        public async Task<IActionResult> Students()
        {
            var students = await _context.Students
                .Include(s => s.IdCard)
                .Include(s => s.Hostel)
                .Include(s => s.MessAllocation)
                .Include(s => s.TransportAllocation)
                .OrderByDescending(s => s.AdmissionDate)
                .ToListAsync();
            
            return View(students);
        }

        // Student Details
        [HttpGet("Students/{id}")]
        public async Task<IActionResult> StudentDetails(int id)
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

            return View(student);
        }

        // Hostel Management
        [HttpGet("Hostels")]
        public async Task<IActionResult> Hostels()
        {
            var hostels = await _context.HostelAllocations
                .Include(h => h.Student)
                .ToListAsync();
            
            return View(hostels);
        }

        // Mess Management
        [HttpGet("Mess")]
        public async Task<IActionResult> Mess()
        {
            var messAllocations = await _context.MessAllocations
                .Include(m => m.Student)
                .ToListAsync();
            
            return View(messAllocations);
        }

        // Transport Management
        [HttpGet("Transport")]
        public async Task<IActionResult> Transport()
        {
            var transports = await _context.TransportAllocations
                .Include(t => t.Student)
                .ToListAsync();
            
            return View(transports);
        }

        // Hostel Leave Management
        [HttpGet("HostelLeaves")]
        public async Task<IActionResult> HostelLeaves()
        {
            var leaves = await _context.HostelLeaves
                .Include(hl => hl.Student)
                .OrderByDescending(hl => hl.AppliedDate)
                .ToListAsync();
            
            return View(leaves);
        }

        // Approve Leave
        [HttpPost("ApproveLeave/{id}")]
        public async Task<IActionResult> ApproveLeave(int id, string remarks)
        {
            var leave = await _context.HostelLeaves.FindAsync(id);
            if (leave == null) return NotFound();

            leave.Status = "Approved";
            leave.ApprovedBy = User.Identity.Name;
            leave.ApprovedDate = DateTime.UtcNow;
            leave.Remarks = remarks;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(HostelLeaves));
        }

        // Reject Leave
        [HttpPost("RejectLeave/{id}")]
        public async Task<IActionResult> RejectLeave(int id, string remarks)
        {
            var leave = await _context.HostelLeaves.FindAsync(id);
            if (leave == null) return NotFound();

            leave.Status = "Rejected";
            leave.ApprovedBy = User.Identity.Name;
            leave.ApprovedDate = DateTime.UtcNow;
            leave.Remarks = remarks;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(HostelLeaves));
        }

        // Class Schedules
        [HttpGet("ClassSchedules")]
        public async Task<IActionResult> ClassSchedules()
        {
            var schedules = await _context.ClassSchedules
                .Include(cs => cs.Student)
                .OrderBy(cs => cs.DayOfWeek)
                .ThenBy(cs => cs.StartTime)
                .ToListAsync();
            
            return View(schedules);
        }
    }
}
