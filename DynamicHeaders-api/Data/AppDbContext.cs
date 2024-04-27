using DynamicHeaders_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace DynamicHeaders_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<SubHeadConfig> subHeadConfigs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubHeadConfig>().OwnsMany(a => a.MetaData, m => { m.ToJson(); });

        base.OnModelCreating(modelBuilder);
    }
}
