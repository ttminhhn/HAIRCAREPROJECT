using HAIRCARE.CORE.Base;
using System.Collections.Generic;

namespace HAIRCARE.CORE.BusinessDomain
{
    public class UserRole : BaseEntityWithDateModified
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
        /// Note
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Users
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}