using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorCabinet.Infrastructure.Persistence.Entities;

namespace TutorCabinet.Infrastructure.Persistence.Configurations;

public class DirectionStudyEntityConfig : IEntityTypeConfiguration<DirectionStudyEntity>
{
    public void Configure(EntityTypeBuilder<DirectionStudyEntity> builder)
    {
        builder.HasKey(ds => ds.Id);
        builder.Property(ds => ds.Name).IsRequired().HasMaxLength(256);
    }
}
