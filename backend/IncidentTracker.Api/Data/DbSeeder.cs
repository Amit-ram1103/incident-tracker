using IncidentTracker.Api.Models;

namespace IncidentTracker.Api.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Incidents.Any())
            return;

        var random = new Random();

        var services = new[] { "Payments", "Orders", "Auth", "Search", "Notifications" };
        var severities = new[] { "SEV1", "SEV2", "SEV3", "SEV4" };
        var statuses = new[] { "OPEN", "MITIGATED", "RESOLVED" };

        var incidents = new List<Incident>();

        for (int i = 1; i <= 200; i++)
        {
            incidents.Add(new Incident
            {
                Id = Guid.NewGuid(),
                Title = $"Incident {i}",
                Service = services[random.Next(services.Length)],
                Severity = severities[random.Next(severities.Length)],
                Status = statuses[random.Next(statuses.Length)],
                Owner = $"user{i % 10}",
                Summary = "Auto-generated test incident",
                CreatedAt = DateTime.UtcNow.AddDays(-random.Next(30)),
                UpdatedAt = DateTime.UtcNow
            });
        }

        context.Incidents.AddRange(incidents);
        context.SaveChanges();
    }
}