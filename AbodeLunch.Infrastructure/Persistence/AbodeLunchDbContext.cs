using AbodeLunch.Domain.Common.Models;
using AbodeLunch.Domain.Menu;
using AbodeLunch.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace AbodeLunch.Infrastructure.Persistence;

public class AbodeLunchDbContext : DbContext
{
    private readonly PublishDomainEventInterceptor _publishDomainEventsInterceptor;
    public AbodeLunchDbContext(DbContextOptions<AbodeLunchDbContext> options, PublishDomainEventInterceptor publishDomainEventInterceptor)
    : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventInterceptor;
    }

    // public DbSet<Bill> Bills { get; set; } = null!;
    // public DbSet<Guest> Guests { get; set; } = null!;
    // public DbSet<Host> Hosts { get; set; } = null!;
    // public DbSet<Dinner> Dinners { get; set; } = null!;
    // public DbSet<MenuReview> MenuReviews { get; set; } = null!;
    // public DbSet<User> Users { get; set; } = null!;
    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(AbodeLunchDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}