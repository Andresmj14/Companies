using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Companies.Domain.Entities;


namespace Companies.Infrastructure.Persistence.Configurations;

public class CitiesConfigurations
{
    public void Configure(EntityTypeBuilder<Cities> builder)
    {
        builder.ToTable("Cities");

        builder.HasKey(c => c.id);
        builder.Property(c => c.id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(c => c.Regions)
            .WithMany(r => r.citiesid)
            .HasForeignKey(c => c.Regionsid)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.companiesid)
            .WithOne(co => co.Cities)
            .HasForeignKey(co => co.Citiesid)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasMany(c => c.branchesid)
            .WithOne(b => b.Cities)
            .HasForeignKey(b => b.Citiesid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
