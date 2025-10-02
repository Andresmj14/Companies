using System;
using Companies.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Companies.Domain.Entities;

namespace Companies.Infrastructure.Persistence.Configurations;

public class RegionsConfiguration: IEntityTypeConfiguration<Regions>
{
    public void Configure(EntityTypeBuilder<Regions> builder)
    {
        builder.ToTable("Regions");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(r => r.Country)
            .WithMany(c => c.Regions)
            .HasForeignKey(r => r.CountryId);
        
        builder.HasMany(r => r.Cities)
            .WithOne(c => c.Region)
            .HasForeignKey(c => c.RegionId);
    }
}
