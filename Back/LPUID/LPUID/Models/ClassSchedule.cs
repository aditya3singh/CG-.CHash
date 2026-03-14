using System.ComponentModel.DataAnnotations;

namespace LPUID.Models
{
    public class ClassSchedule
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        
        [Display(Name = "Day of Week")]
        public string DayOfWeek { get; set; }
        
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }
        
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }
        
        [Display(Name = "Room/Lab")]
        public string RoomNumber { get; set; }
        
        [Display(Name = "Instructor")]
        public string Instructor { get; set; }
        
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        public virtual Student Student { get; set; }
    }
}
