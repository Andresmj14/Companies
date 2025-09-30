using System;
using Companies.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Companies.Domain.Entities;
using System.Linq;

namespace Companies.Infrastructure.Persistence.Configurations;

public sealed class CountriesConfigurations
{
    public void Configure(EntityTypeBuilder<Countries> builder)
    {
        builder.ToTable("Countries");

        builder.HasKey(c => c.id);
        builder.Property(c => c.id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(c => c.Regions)       // Countries → Regions
            .WithOne(r => r.Countries)          // Regions → Country
            .HasForeignKey(r => r.Countriesid);
    }
}
