using System;
using Companies.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Companies.Domain.Entities;
using System.Linq;
using Companies.Application.Abstracctions;

namespace Companies.Infrastructure.Persistence.Configurations;

public class CountriesConfigurations : IEntityTypeConfiguration<Countries>
{
    public void Configure(EntityTypeBuilder<Countries> builder)
    {
        builder.ToTable("Countries");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(c => c.Regions)
       .WithOne(r => r.Country)
       .HasForeignKey(r => r.CountryId);

    }
}
