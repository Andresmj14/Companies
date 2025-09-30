using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
using Companies.Domain.Entities;

namespace Companies.Infrastructure.Persistence.Configurations;

public sealed class BranchesConfigurations
{
    public void Configure(EntityTypeBuilder<Branches> builder)
    {
        builder.ToTable("Branches");

        builder.HasKey(b => b.id);
        builder.Property(b => b.id)
            .ValueGeneratedOnAdd();

        builder.Property(b => b.contact_name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.address)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.email)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(b => b.Cities)
            .WithMany(c => c.branchesid)
            .HasForeignKey(b => b.Citiesid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
