using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLibraryAPI.Domain.Entities;

namespace OnlineLibraryAPI.Services.Persistence.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email).IsRequired();

        builder.HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey("RoleId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
