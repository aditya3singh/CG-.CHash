[ApiController]
[Route("api/[controller]")]
public class StudentsController(AppDbContext context) : ControllerBase
{
    // 1. ADD Student + Hostel (Admin Only)
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateStudent(CreateStudentDto dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            CollegeName = dto.CollegeName,
            Hostel = dto.Hostel != null ? new Hostel
            {
                RoomNumber = dto.Hostel.RoomNumber,
                BlockName = dto.Hostel.BlockName
            } : null
        };

        context.Students.Add(student);
        await context.SaveChangesAsync();
        return Ok(student);
    }

    // 2. UPDATE Student (Admin Only)
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto dto)
    {
        var student = await context.Students.FindAsync(id);
        if (student == null) return NotFound();

        student.Name = dto.Name;
        student.Email = dto.Email;
        student.CollegeName = dto.CollegeName;

        await context.SaveChangesAsync();
        return NoContent();
    }

    // 3. UPDATE ONLY HOSTEL ROOM (Warden or Admin)
    [HttpPut("{studentId}/hostel")]
    [Authorize(Roles = "Warden,Admin")]
    public async Task<IActionResult> UpdateHostel(int studentId, UpdateHostelDto dto)
    {
        var hostel = await context.Hostels.FirstOrDefaultAsync(h => h.StudentId == studentId);
        if (hostel == null) return NotFound("Student has no hostel assigned.");

        hostel.RoomNumber = dto.RoomNumber;
        hostel.BlockName = dto.BlockName;

        await context.SaveChangesAsync();
        return Ok("Hostel room updated successfully.");
    }

    // 4. DELETE Student (Admin Only)
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await context.Students.Include(s => s.Hostel).FirstOrDefaultAsync(s => s.Id == id);
        if (student == null) return NotFound();

        context.Students.Remove(student);
        await context.SaveChangesAsync();
        return Ok("Student and their Hostel record deleted.");
    }
}