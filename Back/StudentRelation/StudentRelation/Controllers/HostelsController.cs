using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentRelation.DTOs;
using StudentRelation.Services;

namespace StudentRelation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class HostelsController : ControllerBase
{
    private readonly IHostelService _hostelService;

    public HostelsController(IHostelService hostelService)
    {
        _hostelService = hostelService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Warden")]
    public async Task<ActionResult<IEnumerable<HostelDto>>> GetAllHostels()
    {
        var hostels = await _hostelService.GetAllHostelsAsync();
        return Ok(hostels);
    }

    [HttpGet("student/{studentId}")]
    [Authorize(Roles = "Admin,Warden")]
    public async Task<ActionResult<HostelDto>> GetHostelByStudentId(int studentId)
    {
        var hostel = await _hostelService.GetHostelByStudentIdAsync(studentId);
        if (hostel == null)
        {
            return NotFound(new { message = "Hostel not found for this student" });
        }

        return Ok(hostel);
    }

    [HttpPut("student/{studentId}")]
    [Authorize(Roles = "Admin,Warden")]
    public async Task<ActionResult<HostelDto>> UpdateHostel(int studentId, UpdateHostelDto updateDto)
    {
        try
        {
            var hostel = await _hostelService.UpdateHostelAsync(studentId, updateDto);
            return Ok(hostel);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("student/{studentId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteHostel(int studentId)
    {
        var result = await _hostelService.DeleteHostelAsync(studentId);
        if (!result)
        {
            return NotFound(new { message = "Hostel not found for this student" });
        }

        return NoContent();
    }
}


