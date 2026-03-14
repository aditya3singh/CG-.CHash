using System.ComponentModel.DataAnnotations;

namespace LPUID.Models
{
    public class MessAllocation
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        
        [Display(Name = "Mess Name")]
        public string MessName { get; set; }
        
        [Display(Name = "Meal Plan")]
        public string? MealPlan { get; set; }
        
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public virtual Student Student { get; set; }
    }
}
