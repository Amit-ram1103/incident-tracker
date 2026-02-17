using IncidentTracker.Api.Models;

namespace IncidentTracker.Api.Repositories;

public interface IIncidentRepository
{
    Task<Incident> CreateAsync(Incident incident);

    Task<(IEnumerable<Incident>, int totalCount)> GetPagedAsync(
        int page,
        int pageSize,
        string? search,
        string? status,
        string? service,
        string? severity);

    Task<Incident?> GetByIdAsync(Guid id);

    Task<Incident?> UpdateAsync(Incident incident);
}