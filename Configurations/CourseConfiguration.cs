using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TmsApi.Entities;

namespace TmsApi.Configurations;

public class CourseConfiguration
    : IEntityTypeConfiguration<Course>
{
    public void Configure(
        EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(100);
    }
}