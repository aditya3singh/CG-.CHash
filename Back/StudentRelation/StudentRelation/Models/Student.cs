namespace StudentRelation.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CollegeName { get; set; } = string.Empty;
    
    // 1:1 relationship with Hostel
    public Hostel? Hostel { get; set; }
}
