namespace LPUID.Models
{
    public class IdCard
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string UniqueCardNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public virtual Student Student { get; set; }
    }
}
