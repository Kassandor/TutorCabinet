using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorCabinet.Infrastructure.Persistence.Entities;

namespace TutorCabinet.Infrastructure.Persistence.Configurations;

public class StudentEntityConfig : IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder.ToTable("students");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(256);
        builder.Property(s => s.ClassNumber).IsRequired();
        builder
            .HasOne(s => s.DirectionStudy)
            .WithMany(d => d.Students)
            .HasForeignKey(s => s.DirectionStudyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
