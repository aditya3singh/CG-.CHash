using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using System.Text;

namespace Project.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentManagementContext _context;

        public StudentsController(StudentManagementContext context)
        {
            _context = context;
        }

        public IActionResult Create(string name, int age, string city)
        {
            var student = new Student
            {
                Name = name,
                Age = age,
                City = city
            };

            _context.Students.Add(student);
            _context.SaveChanges();


            return Content("Student Created Successfully");
        }
        public IActionResult GetAll()
        {
            var students = _context.Students.ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var s in students)
            {
                sb.Append($"{s.Id} - {s.Name} - {s.Age} - {s.City} <br>");
            }

            return Content(sb.ToString(), "text/html");
        }


        //Students/Details/1
        public IActionResult Details(int id)
        {
            var s = _context.Students.Find(id);

            if (s == null)
                return Content("Student not found");

            return Content($"{s.Id} - {s.Name} - {s.Age} - {s.City}");
        }
    }
}
