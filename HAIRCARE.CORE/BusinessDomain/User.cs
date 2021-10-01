using HAIRCARE.CORE.Base;
using HAIRCARE.CORE.BaseEnumeration;
using System;
using System.Collections.Generic;

namespace HAIRCARE.CORE.BusinessDomain
{
    public class User : BaseEntityWithDateModified
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Avatar Image
        /// </summary>
        public string AvatarImg { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Past Password 1
        /// </summary>
        public string PastPassword1 { get; set; }

        /// <summary>
        /// Past Password 2
        /// </summary>
        public string PastPassword2 { get; set; }

        /// <summary>
        /// Past Password 3
        /// </summary>
        public string PastPassword3 { get; set; }

        /// <summary>
        /// Past Password 4
        /// </summary>
        public string PastPassword4 { get; set; }

        /// <summary>
        /// PasswordModifiedDate
        /// </summary>
        public DateTime PasswordModifiedDate { get; set; }

        /// <summary>
        /// PasswordExpirationDate
        /// </summary>
        public DateTime PasswordExpirationDate { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User Role Id
        /// </summary>
        public int UserRoleId { get; set; }

        /// <summary>
        /// User State
        /// </summary>
        public UserState UserState { get; set; }

        /// <summary>
        /// Logged In Date
        /// </summary>
        public DateTime LoggedInDate { get; set; }

        /// <summary>
        /// Previous Logged In Date
        /// </summary>
        public DateTime PreviousLoggedInDate { get; set; }

        /// <summary>
        /// Login Failure Count
        /// </summary>
        public int LoginFailureCount { get; set; }

        /// <summary>
        /// Locked Date Time
        /// </summary>
        public DateTime LockedDateTime { get; set; }

        /// <summary>
        /// Verify Token for New register or reset password
        /// </summary>
        public string VerifyToken { get; set; }

        /// <summary>
        /// Verify Token for New register or reset password
        /// </summary>
        public DateTime VerifyTokenExpirationDate { get; set; }

        /// <summary>
        /// Time zone Id base on system timezone
        /// </summary>
        public string TimezoneId { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// User Role
        /// </summary>
        public virtual UserRole UserRole { get; set; }

        /// <summary>
        /// User Group References
        /// </summary>
        public virtual ICollection<UserGroupReference> UserGroupRefereces { get; set; }
    }
}
