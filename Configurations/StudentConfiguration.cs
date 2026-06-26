using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TmsApi.Entities;

namespace TmsApi.Configurations;

public class StudentConfiguration
    : IEntityTypeConfiguration<Student>
{
    public void Configure(
        EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.RegistrationNumber)
            .IsRequired()
            .HasMaxLength(50);
    }
}