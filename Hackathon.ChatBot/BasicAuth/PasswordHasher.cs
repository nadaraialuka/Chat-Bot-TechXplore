using System.Security.Cryptography;
using System.Text;

namespace Hackathon.ChatBot.BasicAuth
{
    public class SimplePasswordHasher
    {
        private const string Salt = "MYSTRONGSALT112233";
        private const int KeySize = 32;
        private const int Iterations = 10000;

        public string HashPassword(string password)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(Salt);

            var hash = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256);
            byte[] key = hash.GetBytes(KeySize);

            return Convert.ToBase64String(key);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(Salt);

            var hash = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256);
            byte[] key = hash.GetBytes(KeySize);

            return Convert.ToBase64String(key) == hashedPassword;
        }
    }
}
