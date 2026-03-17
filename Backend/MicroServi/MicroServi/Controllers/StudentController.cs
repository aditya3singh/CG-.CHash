using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(Student student)
        {
            var name = student.Name;

            // Reverse the string
            char[] arr = name.ToCharArray();
            Array.Reverse(arr);

            var reversed = new string(arr);

            return Ok(reversed);
        }
    }
}
