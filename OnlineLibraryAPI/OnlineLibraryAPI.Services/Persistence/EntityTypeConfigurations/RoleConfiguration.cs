using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLibraryAPI.Domain.Constants;
using OnlineLibraryAPI.Domain.Entities;

namespace OnlineLibraryAPI.Services.Persistence.EntityTypeConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name).IsRequired();

        builder.HasData(RoleConstants.Roles);
    }
}
