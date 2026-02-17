namespace IncidentTracker.Api.DTOs;

public class UpdateIncidentRequest
{
    public string? Status { get; set; }
    public string? Owner { get; set; }
    public string? Summary { get; set; }
}