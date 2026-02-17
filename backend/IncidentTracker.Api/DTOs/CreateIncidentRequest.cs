namespace IncidentTracker.Api.DTOs;

public class CreateIncidentRequest
{
    public string Title { get; set; } = string.Empty;
    public string Service { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Status { get; set; } = "OPEN";
    public string? Owner { get; set; }
    public string? Summary { get; set; }
}