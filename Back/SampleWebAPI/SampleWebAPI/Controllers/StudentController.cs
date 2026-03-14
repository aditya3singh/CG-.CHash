using Microsoft.AspNetCore.Mvc;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // 1. This class defines the exact JSON structure Postman needs to send
        public class AdditionRequest
        {
            public int Number1 { get; set; }
            public int Number2 { get; set; }
            public int Number3 { get; set; } // Added a third number based on your logic!
        }

        // POST: api/Calculator/add
        [HttpPost("add")]
        public IActionResult AddNumbers([FromBody] AdditionRequest request)
        {
            // 2. Perform the addition dynamically using the data from Postman
            var result = request.Number1 + request.Number2 + request.Number3;

            // 3. Return the calculated result
            return Ok(new
            {
                Input1 = request.Number1,
                Input2 = request.Number2,
                Input3 = request.Number3,
                TotalSum = result
            });
        }
    }
}