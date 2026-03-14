namespace LPUID.Models
{
    public class SemesterMark
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int Semester { get; set; }
        public double TotalMarks { get; set; }
        public double SGPA { get; set; }
        public virtual Student Student { get; set; }
    }
}
