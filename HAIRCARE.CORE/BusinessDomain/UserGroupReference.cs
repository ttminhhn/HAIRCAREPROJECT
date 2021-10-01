
namespace HAIRCARE.CORE.BusinessDomain
{
    public class UserGroupReference
    {
        /// <summary>
        /// User Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// UserGroup
        /// </summary>
        public int UserGroupId { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// User Group
        /// </summary>
        public virtual UserGroup UserGroup { get; set; }
    }
}