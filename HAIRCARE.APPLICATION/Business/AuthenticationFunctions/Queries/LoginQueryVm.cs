using System;
using System.Collections.Generic;
using System.Text;

namespace HAIRCARE.APPLICATION.Business.AuthenticationFunctions.Queries
{
    public class LoginQueryVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public List<string> GroupName { get; set; }
        public int UserState { get; set; }
        public int DeleteFlag { get; set; }
        public int LoginFailureCount { get; set; }
        public string LockedDatetime { get; set; }
        public string PreviousLoggedInDate { get; set; }
        public string AccessToken { get; set; }
    }
}
