using IncidentTracker.Api.Data;
using IncidentTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentTracker.Api.Repositories;

public class IncidentRepository : IIncidentRepository
{
    private readonly AppDbContext _context;

    public IncidentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Incident> CreateAsync(Incident incident)
    {
        _context.Incidents.Add(incident);
        await _context.SaveChangesAsync();
        return incident;
    }

    public async Task<(IEnumerable<Incident>, int)> GetPagedAsync(
    int page,
    int pageSize,
    string? search,
    string? status,
    string? service,
    string? severity)
    {
        var query = _context.Incidents.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                x.Title.Contains(search) ||
                x.Service.Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(x => x.Status.ToLower() == status.ToLower());
        }

        if (!string.IsNullOrWhiteSpace(service))
        {
            query = query.Where(x => x.Service.ToLower() == service.ToLower());
        }

        if (!string.IsNullOrWhiteSpace(severity))
        {
            query = query.Where(x => x.Severity.ToLower() == severity.ToLower());
        }

        var total = await query.CountAsync();

        var data = await query
            .OrderByDescending(x => x.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (data, total);
    }

    public async Task<Incident?> GetByIdAsync(Guid id)
    {
        return await _context.Incidents.FindAsync(id);
    }

    public async Task<Incident?> UpdateAsync(Incident incident)
    {
        _context.Incidents.Update(incident);
        await _context.SaveChangesAsync();
        return incident;
    }
}