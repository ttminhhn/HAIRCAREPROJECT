using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HAIRCARE.CORE.BaseEnumeration;
using HAIRCARE.CORE.BusinessDomain;

namespace HAIRCARE.INFRASTRUCTURE.Context.Configurations
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.ToTable("user_group_mst");

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

            builder.HasMany(e => e.UserGroupRefereces).WithOne(e => e.UserGroup).HasForeignKey(e => e.UserGroupId);
        }
    }
}
