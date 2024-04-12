using ead_csharp_cp2.Models;
using Microsoft.EntityFrameworkCore;

namespace ead_csharp_cp2.Persistence;

public class PostgresDbContext : DbContext
{
    public DbSet<FootballTeam> FootballTeams { get; set; }
    
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}