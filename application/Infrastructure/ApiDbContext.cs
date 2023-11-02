using application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace application.Infrastructure;

public class ApiDbContext : DbContext
{
    public ApiDbContext() { }
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<Color> Colors => Set<Color>();
    public DbSet<WeightRegistry> WeightRegistries => Set<WeightRegistry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
    }
}
