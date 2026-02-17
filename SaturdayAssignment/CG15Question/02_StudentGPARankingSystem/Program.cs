using System;
using Domain;
using Services;
using Exceptions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentUtility utility = new StudentUtility();
            Console.WriteLine("=== University GPA Ranking System ===");

            while (true)
            {
                Console.WriteLine("\n1. Display Ranking | 2. Update GPA | 3. Add Student | 4. Exit");
                Console.Write("Selection: ");

                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                try
                {
                    switch (choice)
                    {
                        case 1:
                            var students = utility.GetRanking();
                            foreach (var s in students) Console.WriteLine(s);
                            break;

                        case 2:
                            Console.Write("Enter Student ID: ");
                            string id = Console.ReadLine();
                            Console.Write("Enter New GPA: ");
                            double gpa = double.Parse(Console.ReadLine());
                            utility.UpdateGPA(id, gpa);
                            Console.WriteLine("GPA Updated and Ranking Recalculated.");
                            break;

                        case 3:
                            Console.WriteLine("Input: ID Name GPA");
                            string[] input = Console.ReadLine().Split(' ');
                            utility.AddStudent(new Student
                            {
                                Id = input[0],
                                Name = input[1],
                                GPA = double.Parse(input[2])
                            });
                            Console.WriteLine("Student Added.");
                            break;

                        case 4:
                            Console.WriteLine("Thank You");
                            return;
                    }
                }
                catch (CustomBaseException ex)
                {
                    Console.WriteLine($"[Error] {ex.Message}");
                }
                catch (Exception)
                {
                    Console.WriteLine("[System Error] Invalid input format.");
                }
            }
        }
    }
}