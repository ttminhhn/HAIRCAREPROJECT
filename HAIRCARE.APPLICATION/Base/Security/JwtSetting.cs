using System;
using System.Collections.Generic;
using System.Text;

namespace HAIRCARE.APPLICATION.Base.Security
{
    public static class JwtSetting
    {
        public const string SECRET = "kiofj12390ur023fn!98u230ojf9uv23nr2937845234j1o24083513ngf0932g7yu203975u823heokbvnwe9orghj03497y";
        public const int SIGNIN_EXPIRE_MINUTES = 1440;
        public const int SIGNIN_EXPIRE_DAY = 30;
        public const int VERIFY_TOKEN_EXPIRE_DAY = 1;
    }
}
