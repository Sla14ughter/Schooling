using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace Shooling.Crypt
{
    public class PasswordHasher
    {
        public string GetHash(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            using (Argon2id argon2 = new Argon2id(Encoding.UTF8.GetBytes(password)))
            {
                argon2.Salt = saltBytes;
                argon2.DegreeOfParallelism = 8;
                argon2.MemorySize = 65536;
                argon2.Iterations = 1000;
                byte[] hash = argon2.GetBytes(32);
                return Convert.ToBase64String(hash);
            }
        }
        public string NewSalt()
        {
            byte[] salt = new byte[16];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }
    }
}
