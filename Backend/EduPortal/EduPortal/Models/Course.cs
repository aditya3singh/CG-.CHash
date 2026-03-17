using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [Display(Name = "Course Title")]
        public string Title { get; set; } = string.Empty;

        public int Credits { get; set; }

        // Navigation Property: One Course has Many Students
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}