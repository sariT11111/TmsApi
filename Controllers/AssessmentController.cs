using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TmsApi.Controllers;

[ApiController]
[Route("api/assessments")]
public class AssessmentController : ControllerBase
{
    [HttpGet("results")]
    [Authorize]
    public IActionResult GetResults()
    {
        return Ok(new
        {
            Course = "Web Development",
            AverageGrade = 87
        });
    }
}