using System;
using System.Collections.Generic;
using System.Text;

namespace HAIRCARE.APPLICATION.Business.AuthenticationFunctions.Queries.FogotPassWordQuery
{
    public class FogotPassWordQueryVm
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string VerifyToken { get; set; }
    }
}
