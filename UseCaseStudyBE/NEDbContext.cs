using Microsoft.EntityFrameworkCore;
using UseCaseStudyBE.Models;

namespace UseCaseStudyBE;

public class NEDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=NEDatabase;Username=maliaydemir;Password=postgres");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id).IsUnique();
        });
    }
    public DbSet<Activity> Activities { get; set; }
}