using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Clinetview.Models;

namespace Clinetview.Controllers
{
    public class CoursesController : Controller
    {
        private readonly string _connectionString;

        public CoursesController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Courses", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            courses.Add(new Course
                            {
                                CourseId = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Credits = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Course course)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Courses (Title, Credits) VALUES (@Title, @Credits)", con))
                {
                    cmd.Parameters.AddWithValue("@Title", course.Title);
                    cmd.Parameters.AddWithValue("@Credits", course.Credits);
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Index");
        }
    }
}