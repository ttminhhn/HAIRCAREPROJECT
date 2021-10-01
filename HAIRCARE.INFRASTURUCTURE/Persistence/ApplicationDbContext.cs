using Microsoft.EntityFrameworkCore;
using HAIRCARE.APPLICATION.Base.Interfaces;
using System.Reflection;
using HAIRCARE.CORE.BusinessDomain;


namespace HAIRCARE.INFRASTURUCTURE.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(
           DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserGroupReference> UserGroupReferences { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
