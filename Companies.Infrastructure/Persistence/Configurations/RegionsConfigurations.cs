using System;
using Companies.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Companies.Domain.Entities;

namespace Companies.Infrastructure.Persistence.Configurations;

public sealed class RegionsConfigurations : IEntityTypeConfiguration<Regions>
{
    public void Configure(EntityTypeBuilder<Regions> builder)
    {
        builder.ToTable("Regions");

        builder.HasKey(r => r.id);
        builder.Property(r => r.id)
            .ValueGeneratedOnAdd();

        builder.Property(r => r.name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(r => r.Countries)    // Regions → Country
            .WithMany(c => c.Regions)       // Countries → Regions
            .HasForeignKey(r => r.Countriesid);

    }
}
