namespace StudentRelation.DTOs;

public class StudentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CollegeName { get; set; } = string.Empty;
    public HostelDto? Hostel { get; set; }
}

public class CreateStudentDto
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CollegeName { get; set; } = string.Empty;
    public CreateHostelDto? Hostel { get; set; }
}

public class UpdateStudentDto
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CollegeName { get; set; } = string.Empty;
}
