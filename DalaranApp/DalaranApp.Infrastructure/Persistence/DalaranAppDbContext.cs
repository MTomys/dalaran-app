using DalaranApp.Domain.Admins;
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Bajs;
using DalaranApp.Domain.Plebs;
using Microsoft.EntityFrameworkCore;

namespace DalaranApp.Infrastructure.Persistence;

public class DalaranAppDbContext : DbContext
{
    public DalaranAppDbContext(DbContextOptions<DalaranAppDbContext> options) : base(options)
    {
    }

    public DbSet<Admin> Admins { get; set; } = null!;
    public DbSet<Baj> Bajs { get; set; } = null!;
    public DbSet<Member> Members { get; set; } = null!;
    public DbSet<Pleb> Plebs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DalaranAppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}