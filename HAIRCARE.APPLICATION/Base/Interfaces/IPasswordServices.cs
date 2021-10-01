using System;
using System.Collections.Generic;
using System.Text;

namespace HAIRCARE.APPLICATION.Base.Interfaces
{
    public interface IPasswordServices
    {
        string HashPassword(string password);
        bool Verify(string password, string hash);
    }
}
