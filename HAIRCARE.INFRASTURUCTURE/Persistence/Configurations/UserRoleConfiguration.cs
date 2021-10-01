using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HAIRCARE.CORE.BaseEnumeration;
using HAIRCARE.CORE.BusinessDomain;

namespace HAIRCARE.INFRASTRUCTURE.Context.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("user_role_mst");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Code)
               .IsRequired()
               .HasMaxLength(10);

            builder.Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(e => e.Note)
                .HasMaxLength(200);

            builder.Property(e => e.DeleteFlag)
                .HasConversion(
                    e => e.Value,
                    e => DeleteFlag.FromValue(e))
                .IsRequired()
                .HasDefaultValueSql("(0)");

            builder.HasMany(e => e.Users).WithOne(u => u.UserRole).HasForeignKey(u => u.UserRoleId);
        }
    }
}
