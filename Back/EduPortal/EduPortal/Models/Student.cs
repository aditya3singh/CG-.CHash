using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Foreign Key
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        // Navigation Property: A Student belongs to One Course
        [ForeignKey("CourseId")]
        public virtual Course? Course { get; set; }
    }
}