using GClientViewDB.Models;
using GClientViewDB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GClientViewDB.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Students
        public async Task<IActionResult> Index(string? searchName, string? searchEmail, string? searchStatus)
        {
            List<Student> students;

            if (!string.IsNullOrEmpty(searchName) || !string.IsNullOrEmpty(searchEmail) || !string.IsNullOrEmpty(searchStatus))
            {
                students = await _studentService.SearchAsync(searchName, searchEmail, searchStatus);
            }
            else
            {
                students = await _studentService.GetAllStudentsAsync();
            }

            ViewData["SearchName"] = searchName;
            ViewData["SearchEmail"] = searchEmail;
            ViewData["SearchStatus"] = searchStatus;

            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null) return NotFound();

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,Email,Phone,Status,JoinDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.AddStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FullName,Email,Phone,Status,JoinDate,CreatedAt")] Student student)
        {
            if (id != student.StudentId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _studentService.UpdateStudentAsync(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _studentService.StudentExistsAsync(student.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _studentService.DeleteStudentAsync(id);
            if (!success) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}