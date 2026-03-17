using System.ComponentModel.DataAnnotations;

namespace CollegeApi.DTOs
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage = "Student Name is required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        public string RoomNumber { get; set; }
    }
}