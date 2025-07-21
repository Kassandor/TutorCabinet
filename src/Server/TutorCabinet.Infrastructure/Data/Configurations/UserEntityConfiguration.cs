using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorCabinet.Infrastructure.Data.Models;

namespace TutorCabinet.Infrastructure.Data.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id);
        builder.Property(u => u.Email);
        builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(256);
    }
}