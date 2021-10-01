using System;
using System.Collections.Generic;
using System.Text;

namespace HAIRCARE.APPLICATION.Base.Interfaces
{
    public interface IJwtService
    {
        string CreateAccessToken(JwtClaimSetting setting);
    }
    public class JwtClaimSetting
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
