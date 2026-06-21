using Microsoft.AspNetCore.Mvc;

namespace TmsApi.Controllers;

[ApiController]
[Route("students")]
public class StudentsController : ControllerBase
{
    private static readonly List<StudentDto> Students =
    [
        new StudentDto("S-001", "Abeba", 20, 3.8m),
        new StudentDto("S-002", "Dawit", 22, 3.1m),
        new StudentDto("S-003", "Sari", 21, 3.9m)
    ];

    [HttpGet("all")]
    public IActionResult GetAllStudents()
    {
        return Ok(Students);
    }

    [HttpGet("{id}")]
    public IActionResult GetStudentById(string id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);

        if (student is null)
        {
            return NotFound(new
            {
                message = $"Student {id} was not found."
            });
        }

        return Ok(student);
    }
}

public record StudentDto(
    string Id,
    string Name,
    int Age,
    decimal Gpa);