using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace EmployeeOperations
{
    class Program
    {
        // Constructed connection string using your localdb details + the database we created
        static string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeManagementDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Console.Write("Enter Department Name (e.g., HR, Sales, IT): ");
            string department = Console.ReadLine();

            Console.WriteLine("\n--- Processing Operations ---\n");

            using (SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    con.Open();

                    // 1. Department Employee Lookup
                    GetEmployeesByDepartment(con, department);

                    // 2. Department Strength Count
                    GetDepartmentEmployeeCount(con, department);

                    // 3. Employee Order Report
                    GetEmployeeOrders(con);

                    // 4. Duplicate Employee Records
                    GetDuplicateEmployees(con);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Database Error: {ex.Message}");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void GetEmployeesByDepartment(SqlConnection con, string department)
        {
            Console.WriteLine($"\n--- Employees in {department} ---");
            using (SqlCommand cmd = new SqlCommand("sp_GetEmployeesByDepartment", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Department", department);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["EmpId"]} | Name: {reader["Name"]} | Email: {reader["Email"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No employees found in this department.");
                    }
                }
            }
        }

        static void GetDepartmentEmployeeCount(SqlConnection con, string department)
        {
            Console.WriteLine($"\n--- Employee Count for {department} ---");
            using (SqlCommand cmd = new SqlCommand("sp_GetDepartmentEmployeeCount", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Department", department);

                // Setting up the OUTPUT parameter
                SqlParameter outParam = new SqlParameter("@TotalEmployees", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                cmd.ExecuteNonQuery();

                Console.WriteLine($"Total employees in {department}: {cmd.Parameters["@TotalEmployees"].Value}");
            }
        }

        static void GetEmployeeOrders(SqlConnection con)
        {
            Console.WriteLine("\n--- Employee Order Report ---");
            using (SqlCommand cmd = new SqlCommand("sp_GetEmployeeOrders", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Name: {reader["Name"]} | Dept: {reader["Department"]} | Order ID: {reader["OrderId"]} | Amount: ${reader["OrderAmount"]} | Date: {Convert.ToDateTime(reader["OrderDate"]).ToShortDateString()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No orders found.");
                    }
                }
            }
        }

        static void GetDuplicateEmployees(SqlConnection con)
        {
            Console.WriteLine("\n--- Duplicate Employee Records ---");
            using (SqlCommand cmd = new SqlCommand("sp_GetDuplicateEmployees", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["EmpId"]} | Name: {reader["Name"]} | Phone: {reader["Phone"]} | Email: {reader["Email"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No duplicate records found. Your database is clean!");
                    }
                }
            }
        }
    }
}