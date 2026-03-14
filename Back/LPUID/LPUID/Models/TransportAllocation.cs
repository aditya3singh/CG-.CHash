using System.ComponentModel.DataAnnotations;

namespace LPUID.Models
{
    public class TransportAllocation
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        
        [Display(Name = "Route Number")]
        public string RouteNumber { get; set; }
        
        [Display(Name = "Bus Number")]
        public string BusNumber { get; set; }
        
        [Display(Name = "Pickup Point")]
        public string PickupPoint { get; set; }
        
        [Display(Name = "Drop Point")]
        public string DropPoint { get; set; }
        
        [Display(Name = "Pickup Time")]
        public string PickupTime { get; set; }
        
        [Display(Name = "Drop Time")]
        public string DropTime { get; set; }
        
        [Display(Name = "Monthly Fee")]
        public decimal MonthlyFee { get; set; }

        public virtual Student Student { get; set; }
    }
}
