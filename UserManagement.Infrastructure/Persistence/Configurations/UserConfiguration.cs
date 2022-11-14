using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Application.Entities;

namespace UserManagement.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(p => p.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.UserType)
            .IsRequired();
        
        builder.Property(p => p.CreatedDate)
            .IsRequired();
    }
}