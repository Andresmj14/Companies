using System;
using Companies.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Companies.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    //public DbSet<Product> Products { get; set; } = default!;
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)    
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}
