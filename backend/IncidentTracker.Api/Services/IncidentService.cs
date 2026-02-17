using IncidentTracker.Api.DTOs;
using IncidentTracker.Api.Models;
using IncidentTracker.Api.Repositories;

namespace IncidentTracker.Api.Services;

public class IncidentService : IIncidentService
{
    private readonly IIncidentRepository _repository;

    public IncidentService(IIncidentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IncidentResponse> CreateAsync(CreateIncidentRequest request)
    {
        var incident = new Incident
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Service = request.Service,
            Severity = request.Severity,
            Status = request.Status,
            Owner = request.Owner,
            Summary = request.Summary,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var result = await _repository.CreateAsync(incident);

        return Map(result);
    }

    public async Task<(IEnumerable<IncidentResponse>, int)> GetPagedAsync(
        int page,
        int pageSize,
        string? search,
        string? status,
        string? service,
        string? severity)
    {
        var (data, total) = await _repository.GetPagedAsync(
            page, pageSize, search, status, service, severity);

        return (data.Select(Map), total);
    }

    public async Task<IncidentResponse?> GetByIdAsync(Guid id)
    {
        var incident = await _repository.GetByIdAsync(id);
        return incident == null ? null : Map(incident);
    }

    public async Task<IncidentResponse?> UpdateAsync(Guid id, UpdateIncidentRequest request)
    {
        var incident = await _repository.GetByIdAsync(id);
        if (incident == null) return null;

        if (request.Status != null) incident.Status = request.Status;
        if (request.Owner != null) incident.Owner = request.Owner;
        if (request.Summary != null) incident.Summary = request.Summary;

        incident.UpdatedAt = DateTime.UtcNow;

        var updated = await _repository.UpdateAsync(incident);
        return Map(updated!);
    }

    private static IncidentResponse Map(Incident x) => new()
    {
        Id = x.Id,
        Title = x.Title,
        Service = x.Service,
        Severity = x.Severity,
        Status = x.Status,
        Owner = x.Owner,
        Summary = x.Summary,
        CreatedAt = x.CreatedAt
    };
}