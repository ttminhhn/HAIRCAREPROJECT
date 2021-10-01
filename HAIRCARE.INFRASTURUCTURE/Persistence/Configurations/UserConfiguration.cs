using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HAIRCARE.CORE.BaseEnumeration;
using HAIRCARE.CORE.BusinessDomain;

namespace HAIRCARE.INFRASTRUCTURE.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user_mst");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.AvatarImg)
                .HasMaxLength(2000);

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(e => e.PastPassword1)
               .HasMaxLength(256);

            builder.Property(e => e.PastPassword2)
               .HasMaxLength(256);

            builder.Property(e => e.PastPassword3)
               .HasMaxLength(256);

            builder.Property(e => e.PastPassword4)
               .HasMaxLength(256);

            builder.Property(e => e.PasswordModifiedDate)
                .IsRequired();

            builder.Property(e => e.PasswordExpirationDate)
                .IsRequired();

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.UserRoleId)
                .IsRequired();

            builder.Property(e => e.Language)
                .HasMaxLength(5);

            builder.Property(e => e.TimezoneId)
                .HasMaxLength(100);

            builder.Property(e => e.UserState)
                .HasConversion(
                    e => e.Value,
                    e => UserState.FromValue(e))
                .IsRequired()
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.DeleteFlag)
                .HasConversion(
                    e => e.Value,
                    e => DeleteFlag.FromValue(e))
                .IsRequired()
                .HasDefaultValueSql("(0)");

            builder.HasMany(e => e.UserGroupRefereces).WithOne(e => e.User).HasForeignKey(e => e.UserId);
        }
    }
}
