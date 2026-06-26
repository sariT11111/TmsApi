using Microsoft.EntityFrameworkCore;
using TmsApi.Data;
using TmsApi.Entities;

namespace TmsApi.Services;

public class StudentQueryService
{
    private readonly TmsDbContext _context;

    public StudentQueryService(TmsDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetStudentsPageAsync(
        int page,
        CancellationToken ct)
    {
        const int pageSize = 20;

        return await _context.Students
            .OrderBy(s => s.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

public async Task<object> GetTopCoursesAsync(
    CancellationToken ct)
{
    return await _context.Enrollments
        .GroupBy(e => e.Course.Title)
        .Select(g => new
        {
            Course = g.Key,
            Count = g.Count()
        })
        .OrderByDescending(x => x.Count)
        .Take(5)
        .ToListAsync(ct);
}}