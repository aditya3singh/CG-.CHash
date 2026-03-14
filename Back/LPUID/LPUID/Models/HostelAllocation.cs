using System.ComponentModel.DataAnnotations;

namespace LPUID.Models
{
    public class HostelAllocation
    {
        public int Id { get; set; }
        
        [Required]
        public int StudentId { get; set; }
        
        [Required]
        [Display(Name = "Block Name")]
        public string BlockName { get; set; }
        
        [Required]
        [Display(Name = "Room Number")]
        public string RoomNumber { get; set; }
        
        [Display(Name = "Floor")]
        public int Floor { get; set; }
        
        [Display(Name = "Bed Number")]
        public string BedNumber { get; set; }
        
        [Display(Name = "Room Type")]
        public string RoomType { get; set; } // Single, Double, Triple, Quad
        
        [Display(Name = "Allocation Date")]
        public DateTime AllocationDate { get; set; } = DateTime.UtcNow;
        
        [Display(Name = "Check-in Time")]
        public string CheckInTime { get; set; } = "6:00 AM";
        
        [Display(Name = "Check-out Time")]
        public string CheckOutTime { get; set; } = "10:00 PM";
        
        [Display(Name = "Warden Name")]
        public string? WardenName { get; set; }
        
        [Display(Name = "Warden Contact")]
        public string? WardenContact { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public virtual Student Student { get; set; }
    }
}
