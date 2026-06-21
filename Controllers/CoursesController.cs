using Microsoft.AspNetCore.Mvc;

namespace TmsApi.Controllers;

[ApiController]
[Route("courses")]
public class CoursesController : ControllerBase
{
    private static readonly List<CourseDto> Courses =
    [
        new CourseDto("CS-101", "C# Fundamentals", 30),
        new CourseDto("WEB-201", "ASP.NET Core Web API", 25),
        new CourseDto("DB-301", "Database Design", 20)
    ];

    [HttpGet("all")]
    public IActionResult GetAllCourses()
    {
        return Ok(Courses);
    }

    [HttpGet("{id}")]
    public IActionResult GetCourseById(string id)
    {
        var course = Courses.FirstOrDefault(c => c.Id == id);

        if (course is null)
        {
            return NotFound(new
            {
                message = $"Course {id} was not found."
            });
        }

        return Ok(course);
    }
}

public record CourseDto(
    string Id,
    string Title,
    int Capacity);