using Microsoft.EntityFrameworkCore;
using HAIRCARE.CORE.BusinessDomain;
using System.Threading;
using System.Threading.Tasks;

namespace HAIRCARE.APPLICATION.Base.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<UserGroup> UserGroups { get; set; }
        DbSet<UserGroupReference> UserGroupReferences { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
