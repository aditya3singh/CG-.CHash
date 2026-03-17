using System.ComponentModel.DataAnnotations;

namespace LPUID.Models
{
    public class Student
    {
        public int Id { get; set; }
        
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
        public string? ProfilePicturePath { get; set; }

        public DateTime AdmissionDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public virtual HostelAllocation? Hostel { get; set; }
        public virtual ICollection<SemesterMark>? SemesterMarks { get; set; }
        public virtual IdCard? IdCard { get; set; }
        public virtual MessAllocation? MessAllocation { get; set; }
        public virtual TransportAllocation? TransportAllocation { get; set; }
        public virtual ICollection<HostelLeave>? HostelLeaves { get; set; }
        public virtual ICollection<ClassSchedule>? ClassSchedules { get; set; }
    }
}
