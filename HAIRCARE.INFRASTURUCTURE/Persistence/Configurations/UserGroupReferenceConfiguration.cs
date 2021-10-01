using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HAIRCARE.CORE.BusinessDomain;

namespace HAIRCARE.INFRASTRUCTURE.Context.Configurations
{
    public class UserGroupReferenceConfiguration : IEntityTypeConfiguration<UserGroupReference>
    {
        public void Configure(EntityTypeBuilder<UserGroupReference> builder)
        {
            builder.ToTable("user_group_ref");
            builder.HasKey(e => new { e.UserId, e.UserGroupId });

            builder.HasOne(e => e.User).WithMany(e => e.UserGroupRefereces).HasForeignKey(e => e.UserId);
            builder.HasOne(e => e.UserGroup).WithMany(e => e.UserGroupRefereces).HasForeignKey(e => e.UserGroupId);
        }
    }
}
