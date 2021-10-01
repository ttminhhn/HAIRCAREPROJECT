using HAIRCARE.CORE.Base;
using System.Collections.Generic;

namespace HAIRCARE.CORE.BusinessDomain
{
    public class UserGroup : BaseEntityWithDateModified
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// User Group References
        /// </summary>
        public virtual ICollection<UserGroupReference> UserGroupRefereces { get; set; }
    }
}