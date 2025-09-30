using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Companies.Domain.Entities;


namespace Companies.Infrastructure.Persistence.Configurations;

public sealed class CompaniesConfigurations
{
    public void Configure(EntityTypeBuilder<Companie> builder)
    {
        builder.ToTable("Companies");

        builder.HasKey(c => c.id);
        builder.Property(c => c.id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.name)
            .IsRequired()
            .HasMaxLength(100);

        builder.OwnsOne(c => c.Ukniu, u =>
        {
            u.Property(uk => uk.Value)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Ukniu");
        });

        builder.Property(c => c.address)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.email)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(c => c.Cities)
            .WithMany()
            .HasForeignKey(c => c.Citiesid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
