using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text;
using System.Collections.Generic; // Added for List<Employee>
using EmployeeApplication.Models;

namespace EmployeeApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        // Constructor Dependency Injection to read from appsettings.json
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        // GET: Employee/Index (Displays the list of employees)
        public IActionResult Index()
        {
            List<Employee> employeeList = new List<Employee>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Employees";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee emp = new Employee
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Age = Convert.ToInt32(reader["Age"]),
                                City = reader["City"].ToString(),
                                Address = reader["Address"].ToString(),
                                AadharCard = reader["AadharCard"].ToString(),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                Salary = Convert.ToDecimal(reader["Salary"])
                            };
                            employeeList.Add(emp);
                        }
                    }
                }
            }

            return View(employeeList);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Employees (Name, Age, City, Address, AadharCard, DOB, Salary) VALUES (@Name, @Age, @City, @Address, @AadharCard, @DOB, @Salary)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", emp.Name);
                        cmd.Parameters.AddWithValue("@Age", emp.Age);
                        cmd.Parameters.AddWithValue("@City", emp.City);
                        cmd.Parameters.AddWithValue("@Address", emp.Address);
                        cmd.Parameters.AddWithValue("@AadharCard", emp.AadharCard);
                        cmd.Parameters.AddWithValue("@DOB", emp.DOB);
                        cmd.Parameters.AddWithValue("@Salary", emp.Salary);

                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            ViewBag.Message = "Employee saved successfully!";
                            ModelState.Clear(); // Clears form after successful save
                        }
                        catch (SqlException ex)
                        {
                            // Error 2627 is a Unique Constraint Violation
                            if (ex.Number == 2627)
                            {
                                ModelState.AddModelError("AadharCard", "An employee with this Aadhar Card already exists.");
                            }
                            else
                            {
                                ModelState.AddModelError("", "A database error occurred: " + ex.Message);
                            }
                        }
                    }
                }
            }
            return View(emp);
        }

        // GET: Employee/DownloadData
        public IActionResult DownloadData()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Id,Name,Age,City,Address,AadharCard,DOB,Salary");

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Employees";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sb.AppendLine($"{reader["Id"]},{reader["Name"]},{reader["Age"]},{reader["City"]},\"{reader["Address"]}\",{reader["AadharCard"]},{Convert.ToDateTime(reader["DOB"]).ToShortDateString()},{reader["Salary"]}");
                        }
                    }
                }
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "EmployeeData.csv");
        }
    }
}