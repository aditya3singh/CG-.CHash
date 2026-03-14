namespace StudentRelation.Models;

public class Hostel
{
    public int Id { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public string BlockName { get; set; } = string.Empty;
    
    // Foreign key for 1:1 relationship
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
}
