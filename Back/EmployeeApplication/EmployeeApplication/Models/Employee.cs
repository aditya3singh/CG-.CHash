using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApplication.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be at least 2 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Aadhar Card is required.")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Aadhar Card must be exactly 12 digits.")]
        public string AadharCard { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(1000, 1000000, ErrorMessage = "Please enter a valid salary amount.")]
        public decimal Salary { get; set; }
    }
}   