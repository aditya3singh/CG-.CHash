namespace Clinetview.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Grade { get; set; }

        // Extra properties to display names instead of just IDs on the website
        public string StudentName { get; set; }
        public string CourseTitle { get; set; }
    }
}