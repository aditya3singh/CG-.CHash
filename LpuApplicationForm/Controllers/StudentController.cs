using Microsoft.AspNetCore.Mvc;
using LpuApplicationForm.Models;
using LpuApplicationForm.Repository;

namespace LpuApplicationForm.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _repo;

        public StudentController(StudentRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var students = _repo.GetAllStudent();
            return View(students);
        }

        public IActionResult Create()
        {
            return View(new StudentModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentModel obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (obj.ProfileFile != null && obj.ProfileFile.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        obj.ProfileFile.CopyTo(ms);
                        obj.ProfileImage = ms.ToArray();
                        obj.ImageExtension = Path.GetExtension(obj.ProfileFile.FileName).ToLowerInvariant();
                    }

                    if (_repo.CheckDuplicate(obj.Email, obj.Mobile))
                    {
                        ModelState.AddModelError("", "This Email or Mobile is already registered.");
                        return View(obj);
                    }

                    if (_repo.AddStudent(obj))
                    {
                        TempData["Success"] = "Form Submitted Successfully!";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex) when (ex.Message.Contains("CHK_Student_Age"))
                {
                    ModelState.AddModelError("DOB", "Applicant must be between 16 and 100 years old.");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An unexpected error occurred. Please try again.");
                }
            }
            TempData["Error"] = "Submission failed. Please check the form.";
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return NotFound();
            return View("Create", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.ProfileFile != null && obj.ProfileFile.Length > 0)
                {
                    using var ms = new MemoryStream();
                    obj.ProfileFile.CopyTo(ms);
                    obj.ProfileImage = ms.ToArray();
                    obj.ImageExtension = Path.GetExtension(obj.ProfileFile.FileName).ToLowerInvariant();
                }

                // Duplicate check excluding current ID
                if (_repo.CheckDuplicate(obj.Email, obj.Mobile, obj.StudentId))
                {
                    ModelState.AddModelError("", "Another student is already using this Email or Mobile.");
                    TempData["Error"] = "Duplicate Found!";
                    return View("Create", obj);
                }

                try
                {
                    if (_repo.UpdateStudent(obj))
                    {
                        TempData["Success"] = "Application Updated Successfully!";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex) when (ex.Message.Contains("CHK_Student_Age"))
                {
                    ModelState.AddModelError("DOB", "Applicant must be between 16 and 100 years old.");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An unexpected error occurred. Please try again.");
                }
            }
            return View("Create", obj);
        }

        public IActionResult Delete(int id)
        {
            if (_repo.DeleteStudent(id))
                TempData["Success"] = "Application Deleted!";
            else
                TempData["Error"] = "Failed to delete.";

            return RedirectToAction("Index");
        }

        public IActionResult GenerateIdCard(int id)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) 
                return NotFound();
            
            return View("IdCard", student);
        }
    }
}