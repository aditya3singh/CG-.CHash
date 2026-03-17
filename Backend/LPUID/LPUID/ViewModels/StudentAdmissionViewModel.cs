using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace LPUID.ViewModels
{
    public class StudentAdmissionViewModel
    {
        [Required(ErrorMessage = "Application Number is required")]
        [Display(Name = "Application Number")]
        public string ApplicationNumber { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Course is required")]
        [Display(Name = "Course/Program")]
        public string Course { get; set; }

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public string? Gender { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile picture is required")]
        public IFormFile ProfilePicture { get; set; }
    }
}
