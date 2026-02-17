using IncidentTracker.Api.DTOs;

namespace IncidentTracker.Api.Services;

public interface IIncidentService
{
    Task<IncidentResponse> CreateAsync(CreateIncidentRequest request);

    Task<(IEnumerable<IncidentResponse>, int total)> GetPagedAsync(
        int page,
        int pageSize,
        string? search,
        string? status,
        string? service,
        string? severity);

    Task<IncidentResponse?> GetByIdAsync(Guid id);

    Task<IncidentResponse?> UpdateAsync(Guid id, UpdateIncidentRequest request);
}