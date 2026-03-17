using System.ComponentModel.DataAnnotations;

namespace LPUID.Models
{
    public class HostelLeave
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        
        [Display(Name = "Leave From")]
        [DataType(DataType.Date)]
        public DateTime LeaveFrom { get; set; }
        
        [Display(Name = "Leave To")]
        [DataType(DataType.Date)]
        public DateTime LeaveTo { get; set; }
        
        [Display(Name = "Reason")]
        public string Reason { get; set; }
        
        [Display(Name = "Status")]
        public string Status { get; set; } = "Pending";
        
        [Display(Name = "Applied Date")]
        public DateTime AppliedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Approved By")]
        public string? ApprovedBy { get; set; }

        [Display(Name = "Approved Date")]
        public DateTime? ApprovedDate { get; set; }

        [Display(Name = "Remarks")]
        public string? Remarks { get; set; }

        public virtual Student Student { get; set; }
    }
}
