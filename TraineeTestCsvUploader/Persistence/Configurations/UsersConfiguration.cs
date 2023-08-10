using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(128);
            builder.Property(e => e.Married).HasDefaultValue(false);
            builder.Property(e=>e.DateOfBirth).HasDefaultValue(new DateTime(1972, 01, 01));
        }
    }
}
