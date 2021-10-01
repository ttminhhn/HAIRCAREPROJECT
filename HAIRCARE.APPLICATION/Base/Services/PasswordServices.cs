using HAIRCARE.APPLICATION.Base.Interfaces;


namespace HAIRCARE.APPLICATION.Base.Services
{
    public class PassWordServices : IPasswordServices
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string password, string hash)
        {
            var result = BCrypt.Net.BCrypt.Verify(password, hash);

            return result;
        }
    }
}
