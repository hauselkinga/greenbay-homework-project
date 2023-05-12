using System.Security.Cryptography;
using System.Text;

namespace GreenBay_Backend.Helpers
{
    public class UserHelper : IUserHelper
    {
        public string HashPassword(string password)
        {
            SHA256 sha256 = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedPassword = sha256.ComputeHash(passwordBytes);
            var hexPassword = Convert.ToHexString(hashedPassword);
            return hexPassword;
        }
    }
}
