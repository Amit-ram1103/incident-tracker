using IncidentTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentTracker.Api.Data;

public class AppDbContext : DbContext
{
    public DbSet<Incident> Incidents => Set<Incident>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasIndex(x => x.Status);
            entity.HasIndex(x => x.CreatedAt);

            entity.Property(x => x.Title).IsRequired().HasMaxLength(200);
            entity.Property(x => x.Service).IsRequired().HasMaxLength(100);
        });
    }
}