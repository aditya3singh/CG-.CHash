using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LpuApplicationForm.Models;

namespace LpuApplicationForm.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be at least 3 characters long")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name cannot contain numbers")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid email (e.g. john@example.com)")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Mobile must be 10 digits and start with 6, 7, 8, or 9")]
        public string Mobile { get; set; } = string.Empty;

        [Required(ErrorMessage = "Select Gender")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "DOB is required")]
        [DataType(DataType.Date)]
        [EligibleAge(16, 100)]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Address must be at least 10 characters")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "City must be at least 3 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City cannot contain numbers")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "State must be at least 4 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "State can only contain letters")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pincode is required")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Pincode must be exactly 6 digits")]
        public string Pincode { get; set; } = string.Empty;

        [Required(ErrorMessage = "10th Marks required")]
        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100")]
        public decimal? HighSchoolMarks { get; set; } // Fixed with ?

        [Required(ErrorMessage = "12th Marks required")]
        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100")]
        public decimal? IntermediateMarks { get; set; } // Fixed with ?

        [Required(ErrorMessage = "Please select a course")]
        public string CourseApplied { get; set; } = string.Empty;

        public byte[]? ProfileImage { get; set; }

        public string? ImageExtension { get; set; }

        [NotMapped]
        [MaxFileSizeAndResolution]
        public IFormFile? ProfileFile { get; set; }
    }
}