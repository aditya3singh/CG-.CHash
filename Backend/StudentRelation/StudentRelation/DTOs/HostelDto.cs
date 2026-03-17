namespace StudentRelation.DTOs;

public class HostelDto
{
    public int Id { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public string BlockName { get; set; } = string.Empty;
    public int StudentId { get; set; }
}

public class CreateHostelDto
{
    public string RoomNumber { get; set; } = string.Empty;
    public string BlockName { get; set; } = string.Empty;
}

public class UpdateHostelDto
{
    public string RoomNumber { get; set; } = string.Empty;
    public string BlockName { get; set; } = string.Empty;
}
