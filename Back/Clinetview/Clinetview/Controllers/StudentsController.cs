using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Clinetview.Models;

namespace Clinetview.Controllers
{
    public class StudentsController : Controller
    {
        private readonly string _connectionString;

        public StudentsController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                StudentId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return View(students);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Student student)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Students (Name, Email) VALUES (@Name, @Email)", con))
                {
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Index");
        }
    }
}