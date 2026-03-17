using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Clinetview.Models;

namespace Clinetview.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly string _connectionString;

        public EnrollmentsController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = @"SELECT e.EnrollmentId, e.StudentId, e.CourseId, e.Grade, s.Name, c.Title 
                                 FROM Enrollments e
                                 JOIN Students s ON e.StudentId = s.StudentId
                                 JOIN Courses c ON e.CourseId = c.CourseId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            enrollments.Add(new Enrollment
                            {
                                EnrollmentId = reader.GetInt32(0),
                                StudentId = reader.GetInt32(1),
                                CourseId = reader.GetInt32(2),
                                Grade = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                StudentName = reader.GetString(4),
                                CourseTitle = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return View(enrollments);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Enrollment enrollment)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Enrollments (StudentId, CourseId, Grade) VALUES (@StudentId, @CourseId, @Grade)", con))
                {
                    cmd.Parameters.AddWithValue("@StudentId", enrollment.StudentId);
                    cmd.Parameters.AddWithValue("@CourseId", enrollment.CourseId);
                    cmd.Parameters.AddWithValue("@Grade", enrollment.Grade ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Index");
        }
    }
}