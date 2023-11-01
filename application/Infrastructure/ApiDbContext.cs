using application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace application.Infrastructure;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<Color> PetColors => Set<Color>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
    }
}
