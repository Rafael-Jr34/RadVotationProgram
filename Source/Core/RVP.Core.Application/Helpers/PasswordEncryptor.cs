
using System.Text;
using Isopoh.Cryptography.Argon2;
using RVP.Core.Application.Interfaces.HelpersInterfaces;
namespace RVP.Core.Application.Helpers
{
    internal class PasswordEncryptor: IPasswordEncyptor
    {
        public  string HashPassword(string password)
        {
            byte[] passwordBytesPart1 = Encoding.UTF8.GetBytes(password);
            string passwordBytesPart2 =Convert.ToBase64String(passwordBytesPart1);

            string hashedPassword = Argon2.Hash(passwordBytesPart2);

            
            return hashedPassword;
        }

        
        public  bool VerifyPassword(string plainPassword, string storedHash)
        {
            byte[] passwordBytesPart0 = Encoding.UTF8.GetBytes(plainPassword);
            string passwordBytesPart01 = Convert.ToBase64String(passwordBytesPart0);


            return Argon2.Verify(storedHash, passwordBytesPart01);
        }
    }
}
