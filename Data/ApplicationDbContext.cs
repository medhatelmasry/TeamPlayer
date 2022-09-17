using Microsoft.EntityFrameworkCore;
using TeamPlayer.Models;

namespace TeamPlayer.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Player>().Property(m => m.TeamName).IsRequired();

        builder.Entity<Team>().Property(p => p.TeamName).HasMaxLength(30);

        builder.Entity<Team>().ToTable("Team");
        builder.Entity<Player>().ToTable("Player");

        builder.Seed();
    }


    public DbSet<Team>? Teams { get; set; }
    public DbSet<Player>? Players { get; set; }
}
